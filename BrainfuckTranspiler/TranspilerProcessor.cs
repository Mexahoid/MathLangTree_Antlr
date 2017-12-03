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

            //if (isVariable)
            {
                // ProcessVariableEquality(node);
                ProcessQueueableEquality(node);
            }
            //else
                //ProcessIntegerEquality(node);
        }

        private void ProcessIntegerEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);

            LoadToAccumulator(var2.Text);
            Move(_accumulatorPtr, _varTable[var1.Text], '+');
        }

        private void ProcessVariableEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);

            if (_reserved.Contains(var2.Text))
            {
                ProcessPrimitiveOperation(var2);
                Move(_summatorPtr, _varTable[var1.Text], '+');
            }
            else
                Copy(_varTable[var2.Text], _varTable[var1.Text]);
        }


        private void ProcessQueueableEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);
            //if (_reserved.Contains(var2.Text)) // *+-/
            {
                InitQueue(var2);
            }
            ProcessQueue();
            Copy(_accumulatorPtr, _varTable[var1.Text]);
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
            bool acc = false;
            Action<char> act;

            while (_operationsQueue.Count > 0)
            {
                if (!acc)
                {
                    LoadToAccumulator(_operationsQueue.Dequeue().Text);
                    acc = true;
                }
                if (_operationsQueue.Count == 0)
                    return;
                LoadToBase(_operationsQueue.Dequeue().Text);
                

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
                Move(_summatorPtr, _accumulatorPtr, '+');
            }
        }


        private void ProcessPrint(AstNode node)
        {
            if (!node.Text.Equals("print"))
                return;
            AstNode var = node.GetChild(0);
            Goto(_varTable[var.Text]);
            _code.Append('.');
        }

        private void ProcessInput(AstNode node)
        {
            if (!node.Text.Equals("input"))
                return;
            AstNode var = node.GetChild(0);
            Goto(_varTable[var.Text]);
            _code.Append(',');
        }

        // + - * /
        private void ProcessPrimitiveOperation(AstNode node)
        {

            Action<char> act;
            switch (node.Text)
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


            AstNode varNode = node.GetChild(0);
            AstNode valueNode = node.GetChild(1);

            LoadToAccumulator(varNode.Text);
            LoadToBase(valueNode.Text);
            act(node.Text[0]);
        }
    }
}
