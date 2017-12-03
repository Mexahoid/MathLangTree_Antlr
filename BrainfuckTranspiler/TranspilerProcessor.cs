using System;
using System.Collections.Generic;
using System.Linq;
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

            if (isVariable)
                ProcessVariableEquality(node);
            else
                ProcessIntegerEquality(node);
        }

        private void ProcessIntegerEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);

            int.TryParse(var2.Text, out int value);
            if (value < 0)
                throw new ArgumentException();

            LoadValueToAccumulator(value);
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
            bool varIsOp = _reserved.Contains(varNode.Text);
            bool valueIsOp = _reserved.Contains(valueNode.Text);
            if (varIsOp)
                ProcessPrimitiveOperation(varNode);
            if (valueIsOp)
                ProcessPrimitiveOperation(valueNode);
            bool varIsVar = !int.TryParse(varNode.Text, out int var);
            bool valueIsValue = int.TryParse(valueNode.Text, out int value);


            // V + 10 или V - 10
            // V * 10 или V / 10
            if (varIsVar && valueIsValue)
            {
                LoadVariableToAccumulator(varIsOp ? _summatorPtr : _varTable[varNode.Text]);
                LoadValueToBase(value); // Загрузили число в регистр В
                act(node.Text[0]);
                return;
            }

            // 10 + V или 10 - V
            if (!varIsVar && !valueIsValue)
            {
                LoadValueToAccumulator(var); // Загрузили число в регистр В
                LoadVariableToBase(_varTable[valueNode.Text]);
                act(node.Text[0]);
                return;
            }

            // Если 10 + 10 или 10 - 10, то легче всего
            // Если 10 * 10 или 10 / 10
            if (!varIsVar && valueIsValue)
            {
                LoadValueToBase(var);
                LoadValueToAccumulator(value);
                act(node.Text[0]);
                return;
            }

            // Если V + В или V - B
            // Если V * В или V / B
            if (varIsVar && !valueIsValue)
            {
                LoadVariableToAccumulator(_varTable[varNode.Text]);
                LoadVariableToBase(_varTable[valueNode.Text]);

                act(node.Text[0]);

                return;
            }

            throw new Exception("Какая-то невероятная ошибка");
        }
    }
}
