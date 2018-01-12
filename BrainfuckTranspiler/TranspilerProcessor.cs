using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using AstNode = Antlr.Runtime.Tree.ITree;

namespace BrainfuckTranspiler
{
    public partial class Transpiler
    {
        private void ProcessEquality(AstNode node)
        {
            AstNode var2 = node.GetChild(1);

            bool isVariable = !int.TryParse(var2.Text, out int value);
            //Просто проверка на дебила
            if (isVariable)
                if (!_varTable.ContainsKey(var2.Text) && !_reserved.Contains(var2.Text))
                    throw new Exception("Присваиваемая переменная отсутствует.");

            ProcessQueueableEquality(node);
        }

        private void ProcessQueueableEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);
            InitQueue(var2);

            ProcessQueue();
            GetFromCollector(_varTable[var1.Text]);
        }

        private void InitQueue(AstNode node)
        {
            if (node.GetChild(0) != null && node.GetChild(1) != null)
            {
                InitQueue(node.GetChild(0));
                InitQueue(node.GetChild(1));
            }
            _operationsQueue.Enqueue(node);
        }

        private void ProcessQueue()
        {
            while (_operationsQueue.Count > 0)
            {
                if (_reserved.Contains(_operationsQueue.Peek().Text))
                {
                    GetFromCollector(_accumulatorPtr);
                    GetFromCollector(_basePtr);
                    Action<char> act;
                    switch (_operationsQueue.Peek().Text)
                    {
                        case "+":
                        case "-":
                            act = Sum;
                            break;
                        case "*":
                        case "/":
                            act = Mult;
                            break;
                        default:
                            act = c => throw new ArgumentException();
                            break;
                    }
                    act(_operationsQueue.Dequeue().Text[0]);
                    LoadToCollector(_summatorPtr);
                }
                else
                    LoadToCollector(_operationsQueue.Dequeue().Text);
            }
        }


        private void ProcessPrint(AstNode node)
        {
            if (node.Text != "print")
                return;
            AstNode var = node.GetChild(0);
            Goto(_varTable[var.Text]);
            _code.Append('.');
        }

        private void ProcessInput(AstNode node)
        {
            if (node.Text != "input")
                return;
            AstNode var = node.GetChild(0);
            Goto(_varTable[var.Text]);
            _code.Append(',');
        }

        private void ProcessConditionalEquality(AstNode node)
        {
            if (node.GetChild(0).Text == ">" || node.GetChild(0).Text == ">=")
            {
                ProcessInequality(node);
                return;
            }
            int equatorFalsePtr = Size - _ifsInRow * 2;
            int equatorTruePtr = equatorFalsePtr + 1;

            var tuple = ProcessTerm(node);


            Move(_summatorPtr, equatorFalsePtr, '+');   // Перенесли в эквотер
            Goto(equatorFalsePtr);
            string symbol = "+";
            if (tuple.Item3 == ">")
                symbol = "++";
            _code.Append("[>+" + symbol + "<-]>[<+>-]<");
            _code.Append(symbol + "[-[");

            InsertBlock(tuple.Item2);

            Goto(equatorTruePtr);
            _code.Append("-");
            Clear(equatorFalsePtr);
            _code.Append("]>+[<");

            InsertBlock(tuple.Item1);

            Clear(equatorTruePtr);
            _code.Append("]");
            Clear(equatorFalsePtr);
            _code.Append("]");
            _ifsInRow--;
        }


        private void ProcessInequality(AstNode node)
        {
            AstNode condNode = node.GetChild(0);
            //var tuple = ProcessTerm(node);

            
            Copy(_varTable[condNode.GetChild(0).Text], _thresholdPtr);
            Copy(_varTable[condNode.GetChild(1).Text], _valuePtr);
            
            Goto(_valuePtr);
            _code.Append('[');

            Copy(_thresholdPtr, _accumulatorPtr);
            Copy(_valuePtr, _basePtr);

            Sum('-');

            Move(_summatorPtr, _duplicatorPtr, '+');    // Перенесли разницу в D
            Goto(_duplicatorPtr);
            _code.Append("[");
            Goto(_inequalityPtr);
            _code.Append("++");
            Goto(_duplicatorPtr);
            _code.Append("-]");                         // В I записали удвоенную разницу


            Goto(_inequalityPtr);
            _code.Append('[');
            Clear(_inequalityPtr);

            Goto(_helperPtr);           // Перешли на Н
            _code.Append('+');          // Увеличили 
            
            Goto(_inequalityPtr);
            _code.Append(']');          // Увеличили и вышли из цикла I


            Goto(_helperPtr);           // Перешли на Н
            _code.Append("-[");         // Уменьшили и пытаемся начать цикл
            Clear(_helperPtr);
            Clear(_inequalityPtr);
            Goto(_markPtr);
            _code.Append('+');
            Clear(_valuePtr);
            _code.Append('+');
            Clear(_thresholdPtr);
            Goto(_helperPtr);
            _code.Append(']');
            
            Goto(_valuePtr);
            _code.Append("-]");          

            //
            Goto(_markPtr);
            for (int i = 0; i < 65; i++)
            {
                _code.Append('+');
            }
            _code.Append('.');
        }

        private Tuple<AstNode, AstNode, string> ProcessTerm(AstNode node)
        {
            AstNode trueChild = node.GetChild(1);
            AstNode falseChild = node.ChildCount == 3 ? node.GetChild(2) : null;
            AstNode tempNode = node.GetChild(0).GetChild(0);

            if (_reserved.Contains(tempNode.Text))
            {
                EvaluateTo(tempNode, _generalPtr);
                LoadToCollector(_generalPtr);
            }
            else
                LoadToCollector(tempNode.Text);

            tempNode = node.GetChild(0).GetChild(1);

            if (_reserved.Contains(tempNode.Text))
            {
                EvaluateTo(tempNode, _generalPtr + 1);
                LoadToCollector(_generalPtr + 1);
            }
            else
                LoadToCollector(tempNode.Text);

            switch (node.GetChild(0).Text)
            {
                case ">":
                case ">=":
                case "<":
                case "<=":

                    return CurryIf(node);
                case "<>":
                case "==":

                    GetFromCollector(_basePtr);
                    GetFromCollector(_accumulatorPtr);

                    Sum('-');

                    return node.GetChild(0).Text == "<>" ?
                        Tuple.Create(falseChild, trueChild, "<>") :
                        Tuple.Create(trueChild, falseChild, "==");
                default:
                    return null;
            }
        }

        private Tuple<AstNode, AstNode, string> CurryIf(AstNode node)
        {
            AstNode left = node.GetChild(1);
            AstNode right = node.ChildCount < 4 ? node.GetChild(2) : null;

            switch (node.GetChild(0).Text)
            {
                case ">":
                case ">=":
                    return Tuple.Create(left, right, node.GetChild(0).Text);
                case "<":
                    return Tuple.Create(right, left, ">=");
                case "<=":
                    return Tuple.Create(right, left, ">");
            }
            return null;
        }
    }
}
