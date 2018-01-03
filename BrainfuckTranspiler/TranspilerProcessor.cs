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
            int equatorFalsePtr = Size - _ifsInRow * 2;
            int equatorTruePtr = equatorFalsePtr + 1;

            var tuple = ProcessTerm(node);


            Move(_summatorPtr, equatorFalsePtr, '+');   // Перенесли в эквотер
            Goto(equatorFalsePtr);
            string symbol = "+";
            if (node.GetChild(0).Text == ">" || node.GetChild(0).Text == "<")
                symbol = "";
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



        private void ProcessConditionalInequality(AstNode node)
        {
            int equatorFalsePtr = Size - _ifsInRow * 2;
            int equatorTruePtr = equatorFalsePtr + 1;

            var tuple = ProcessTerm(node);
        }

        private Tuple<AstNode, AstNode> ProcessTerm(AstNode node)
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
                    var tuple = CurryIf(node);

                    
                    GetFromCollector(_basePtr);
                    GetFromCollector(_accumulatorPtr);
                    Sum('-');

                    return Tuple.Create(tuple.Item1, tuple.Item2);
                case "<>":
                case "==":
                    
                    GetFromCollector(_accumulatorPtr);
                    GetFromCollector(_basePtr);

                    Sum('-');

                    return node.GetChild(0).Text == "<>" ?
                        Tuple.Create(falseChild, trueChild) :
                        Tuple.Create(trueChild, falseChild);
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
