using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Prnt();
        }

        private void ProcessInput(AstNode node)
        {
            if (node.Text != "input")
                return;
            AstNode var = node.GetChild(0);
            Goto(_varTable[var.Text]);
            Inpt();
        }

        private void ProcessConditions(AstNode node)
        {
            var tuple = ProcessTerm(node);

            switch (tuple.Item3)
            {
                case ">":
                case "<":
                    ProcessStrictInequality(tuple);
                    return;
                case ">=":
                case "<=":
                    ProcessUnstrictInequality(tuple);
                    return;
                case "==":
                case "<>":
                    ProcessConditionalEquality(tuple);
                    return;
            }

        }


        private void ProcessConditionalEquality(Tuple<AstNode, AstNode, string> tuple)
        {
            int equatorFalsePtr = Size - _ifsInRow * 2;
            int equatorTruePtr = equatorFalsePtr + 1;



            Move(_summatorPtr, equatorFalsePtr, '+');   // Перенесли в эквотер
            Goto(equatorFalsePtr);
            _code.Append("[>++<-]>[<+>-]<");
            _code.Append("+[-[");

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


        private void ProcessStrictInequality(
            Tuple<AstNode, AstNode, string> tuple, 
            bool signChanged = false,
            Tuple<Action, Action> Modifier = null)
        {
            int inequatorThresholdPtr = Size - _ifsInRow * 6;
            int inequatorValuePtr = inequatorThresholdPtr + 1;
            int inequatorInequalityPtr = inequatorValuePtr + 1;
            int inequatorHelperPtr = inequatorInequalityPtr + 1;
            int inequatorGeneralFirst = inequatorHelperPtr + 1;
            int inequatorGeneralSecond = inequatorGeneralFirst + 1;
            if (!signChanged)
            {
                GetFromCollector(inequatorValuePtr);
                GetFromCollector(inequatorThresholdPtr);
            }
            if (signChanged)
            {
                Goto(inequatorThresholdPtr);
                Incrt();
            }

            Goto(inequatorGeneralSecond);
            Incrt();

            Goto(inequatorThresholdPtr);
            LpStrt();

            Goto(inequatorGeneralFirst);
            Incrt();

            Goto(inequatorValuePtr);
            LpStrt();

            Copy(inequatorThresholdPtr, _accumulatorPtr);
            Copy(inequatorValuePtr, _basePtr);

            Sum('-');

            Move(_summatorPtr, _duplicatorPtr, '+');    // Перенесли разницу в D
            Goto(_duplicatorPtr);
            LpStrt();
            Goto(inequatorInequalityPtr);
            Incrt();
            Incrt();
            Goto(_duplicatorPtr);
            Decrt();
            LpStp();                      // В I записали удвоенную разницу


            Goto(inequatorInequalityPtr);
            LpStrt();
            Clear(inequatorInequalityPtr);

            Goto(inequatorHelperPtr);           // Перешли на Н
            Incrt();                    // Увеличили 

            Goto(inequatorInequalityPtr);
            LpStp();                    // Увеличили и вышли из цикла I


            Goto(inequatorHelperPtr);           // Перешли на Н
            Decrt();
            LpStrt();
            Clear(inequatorHelperPtr);
            Clear(inequatorInequalityPtr);
            Goto(inequatorGeneralSecond);
            Decrt();
            Clear(inequatorValuePtr);
            Incrt();
            Goto(inequatorHelperPtr);
            LpStp();

            Goto(inequatorValuePtr);
            Decrt();
            LpStp();
            Clear(inequatorThresholdPtr);
            LpStp();
            Clear(inequatorValuePtr);

            Move(inequatorGeneralSecond, inequatorGeneralFirst, '+', false);

            // Если сумма == 1, то это false, если 2, то норм
            Goto(inequatorGeneralFirst);
            Decrt();
            CreateConditionalBlocks(
                inequatorGeneralFirst,
                inequatorGeneralSecond,
                tuple.Item1,
                tuple.Item2,
                Modifier);
            _ifsInRow--;
        }

        private void ProcessUnstrictInequality(Tuple<AstNode, AstNode, string> tuple, 
            Tuple<Action, Action> Modifier = null)
        {
            int inequatorThresholdPtr = Size - _ifsInRow * 6;
            int inequatorValuePtr = inequatorThresholdPtr + 1;
            GetFromCollector(inequatorValuePtr);
            GetFromCollector(inequatorThresholdPtr);

            Copy(inequatorThresholdPtr, _generalPtr);
            Goto(_generalPtr);
            Incrt();                        // Увеличили на 1

            LpStrt();   // Если там не 0, то заходим сюда
            Mvrght();
            Incrt();    // Увеличили G2
            Clear(_generalPtr);
            LpStp();

            Goto(_generalPtr + 1);
            Decrt();    // Если на прошлом шаге не записали 1, то будет 255

            LpStrt();   
            Mvlft();
            Incrt();    // Увеличили G1
            Clear(_generalPtr + 1);
            LpStp();
            // G1  G2
            // 0   0   T != 255
            // 1   0   T == 255

            Goto(_generalPtr);

            LpStrt();

            InsertBlock(tuple.Item1);
            Modifier?.Item1?.Invoke();
            Goto(_generalPtr + 1);
            Incrt();    // Увеличили G2
            Clear(_generalPtr);
            LpStp();

            Goto(_generalPtr + 1);
            Decrt();    // Если на прошлом шаге не записали 1, то будет 255

            LpStrt();

            ProcessStrictInequality(tuple, true, Modifier);

            Clear(_generalPtr);
            Clear(_generalPtr + 1);
            LpStp();
            //_ifsInRow--;
        }

        private void ProcessLoop(AstNode node)
        {
            string op = node.Text;
            if (op == "for")
            {
                ProcessFor(node);
            }
            else
            {
               ProcessWhile(node);
            }
        }

        private void ProcessFor(AstNode node)
        {
            AstNode startOp = node.GetChild(0);
            AstNode condOp = node.GetChild(1);
            AstNode iterOp = node.GetChild(2);
            AstNode mainBlockOp = node.GetChild(3);

            ParseOperation(startOp);
            node.SetChild(0, condOp);
            mainBlockOp.AddChild(iterOp);
            node.SetChild(1, mainBlockOp);
            node.DeleteChild(2);
            node.DeleteChild(2);

            ProcessWhile(node);
        }


        private void ProcessWhile(AstNode node)
        {
            int mainPtr = _loopPtr - _loopsInRow;

            var tuple = ProcessTerm(node);
            switch (tuple.Item3)
            {
                case ">":
                case "<":
                    ProcessStrictInequality(new
                        Tuple<AstNode, AstNode, string>(
                        null, null, tuple.Item3),
                        false
                        ,
                        tuple.Item3 == node.GetChild(0).Text ?
                        new Tuple<Action, Action>(ModifTrue, ModifFalse) :
                        new Tuple<Action, Action>(ModifFalse, ModifTrue));
                    _ifsInRow++;
                    break;
                case ">=":
                case "<=":
                    ProcessUnstrictInequality(new
                            Tuple<AstNode, AstNode, string>(
                                null, null, tuple.Item3),
                        tuple.Item3 == node.GetChild(0).Text ?
                            new Tuple<Action, Action>(ModifTrue, ModifFalse) :
                            new Tuple<Action, Action>(ModifFalse, ModifTrue));
                    _ifsInRow += 2;
                    break;
                case "==":
                case "<>":
                    break;
            }

            void ModifTrue()
            {
                Goto(_duplicatorPtr);
                Incrt();
                LpStrt();
                Goto(mainPtr);
                Incrt();
                Incrt();
                Goto(_duplicatorPtr);
                Decrt();
                LpStp();
                Goto(mainPtr);
            }

            void ModifFalse()
            {
                Clear(mainPtr);
            }

            Goto(mainPtr);
            LpStrt();

            InsertBlock(tuple.Item3 == node.GetChild(0).Text ? tuple.Item1 : tuple.Item2);

            tuple = ProcessTerm(node);
            switch (tuple.Item3)
            {
                case ">":
                case "<":
                    ProcessStrictInequality(new
                            Tuple<AstNode, AstNode, string>(
                                null, null, tuple.Item3), false,
                        tuple.Item3 == node.GetChild(0).Text ?
                            new Tuple<Action, Action>(ModifTrue, ModifFalse) :
                            new Tuple<Action, Action>(ModifFalse, ModifTrue));
                    _ifsInRow++;
                    break;
                case ">=":
                case "<=":
                    ProcessUnstrictInequality(new
                            Tuple<AstNode, AstNode, string>(
                                null, null, tuple.Item3),
                        tuple.Item3 == node.GetChild(0).Text ?
                            new Tuple<Action, Action>(ModifTrue, ModifFalse) :
                            new Tuple<Action, Action>(ModifFalse, ModifTrue));
                    _ifsInRow++;
                    break;
                case "==":
                case "<>":
                    break;
            }


            Goto(mainPtr);
            LpStp();
            _ifsInRow--;
            _loopsInRow--;
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
