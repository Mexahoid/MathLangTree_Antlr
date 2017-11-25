using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Antlr.Runtime.Tree;

using AstNode = Antlr.Runtime.Tree.ITree;

namespace BrainfuckTranspiler
{
    public class Transpiler
    {
        private readonly AstNode _blockNode;
        private readonly IDictionary<string, int> _varTable;
        private readonly IList<string> _reserved;

        private readonly StringBuilder _code;

        /// <summary>
        /// Указывает на последний индекс, принадлежащий переменной
        /// </summary>
        private int _varPtr;

        // |v|a|r|i|a|b|l|e|s|D|A|
        // D - Duplicator
        // A - Accumulator


        private int _innerPtr;
        /// <summary>
        /// Начало секции удвоения
        /// </summary>
        private int _duplicatorPtr;
        private int _accumulatorPtr;
        private int _duplicatorBasePtr;

        private int Ptr
        {
            get => _innerPtr;
            set
            {
                if (value > _innerPtr)
                    for (int i = 0; i < value - _innerPtr; i++)
                        _code.Append('>');
                else if (value < _innerPtr)
                    for (int i = 0; i < _innerPtr - value; i++)
                        _code.Append('<');
                _innerPtr = value;
            }
        }



        public Transpiler(AstNode node)
        {
            _blockNode = node;
            _varTable = new Dictionary<string, int>();
            _reserved = new List<string> { "BLOCK", "=", "input", "print", "-", "+", "*", "/" };
            _code = new StringBuilder();
        }


        public string Transpile()
        {
            for (int i = 0; i < _blockNode.ChildCount; i++)
                FindVars(_blockNode.GetChild(i));
            _accumulatorPtr++;
            _duplicatorBasePtr = _accumulatorPtr + 1;
            //На этом моменте сформирована таблица переменных изначальных
            for (int i = 0; i < _blockNode.ChildCount; i++)
                ParseOperation(_blockNode.GetChild(i));

            return _code.ToString();
        }

        private void FindVars(AstNode node)
        {
            if (_reserved.Contains(node.Text))
            {
                for (int i = 0; i < node.ChildCount; i++)
                    FindVars(node.GetChild(i));
                return;
            }
            if (int.TryParse(node.Text, out int value))
                return;

            if (!_varTable.ContainsKey(node.Text))
            {
                _varTable.Add(node.Text, _varPtr++);
                _duplicatorPtr++;
                _accumulatorPtr++;
            }
        }

        private void ParseOperation(AstNode node)
        {
            switch (node.Text)
            {
                case "=":
                    ProcessEquality(node);
                    break;
                case "print":
                    ProcessPrint(node);
                    break;
                case "input":
                    ProcessInput(node);
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    ProcessPrimitiveOperation(node);
                    break;
            }
        }


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
            
            Clear(_varTable[var1.Text]);

            int.TryParse(var2.Text, out int value);

            for (int i = 0; i < value; i++)
                _code.Append('+');
        }

        private void ProcessVariableEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);

            if (_reserved.Contains(var2.Text))
            {
                ProcessPrimitiveOperation(var2);
                Copy(_accumulatorPtr, _varTable[var1.Text]);
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
            switch (node.Text)
            {
                case "+":
                case "-":
                    ProcessZeroPowerMath(node, node.Text[0]);
                    break;
                case "*":
                case "/":

                    break;
            }
        }

        private void ProcessZeroPowerMath(AstNode node, char sign)
        {
            AstNode varNode = node.GetChild(0);
            AstNode valueNode = node.GetChild(1);
            bool varIsVar = !int.TryParse(varNode.Text, out int var);
            bool valueIsValue = int.TryParse(valueNode.Text, out int value);


            // Сначала рассмотрим случаи, когда V + 10 или 10 + V - сначала копируем значение в А, потом добавляем туда число
           /* if ((varIsVar && valueIsValue) || (!varIsVar && !valueIsValue))
            {
                string nodeText;
                int realValue;
                if (varIsVar)
                {
                    nodeText = varNode.Text;
                    realValue = value;
                }
                else
                {
                    nodeText = valueNode.Text;
                    realValue = var;
                }
                // Теперь работаем с настоящими значениями
                
                Copy(_varTable[nodeText], _accumulatorPtr);             // Скопировали значение в регистр A
                // Есть копия значения ячейки
                Goto(_accumulatorPtr);                                  // Перевели указатель на регистр A

                ZeroPowerMath(realValue, '+');
            }*/

            // V + 10 или V - 10
            if (varIsVar && valueIsValue)
            {
                Copy(_varTable[varNode.Text], _accumulatorPtr);             // Скопировали значение в регистр A
                // Есть копия значения ячейки
                Goto(_accumulatorPtr);                                      // Перевели указатель на регистр A
                ZeroPowerMath(value, sign);
                return;
            }

            // 10 + V или 10 - V
            if (!varIsVar && !valueIsValue)
            {
                Clear(_accumulatorPtr);
                ZeroPowerMath(var, sign);                           // Затолкали в А значение первого узла
                Copy(_varTable[valueNode.Text], _duplicatorPtr);    // Скопировади в D значение второго
                Move(_duplicatorPtr, _accumulatorPtr, sign);        // Добавили или вычли значение
                return;
            }

            // Если 10 + 10 или 10 - 10, то легче всего
            if (!varIsVar && valueIsValue)
            {
                Clear(_accumulatorPtr);         // На регистре А
                ZeroPowerMath(var, '+');
                ZeroPowerMath(value, sign);
                return;
            }

            // Если V + В или V - B
            if (varIsVar && !valueIsValue)
            {
                Copy(_varTable[varNode.Text], _duplicatorPtr);
                Copy(_varTable[valueNode.Text], _accumulatorPtr);
                Move(_duplicatorPtr, _accumulatorPtr, sign, false);           // Перенос в неочищающем режиме
                return;
            }

            throw new Exception("Какая-то невероятная ошибка");
        }

        /// <summary>
        /// Переносим значение из регистра D в нужную ячейку.
        /// </summary>
        /// <param name="from">Откуда переносим.</param>
        /// <param name="to">Куда переносим.</param>
        private void Move(int from, int to, char sign, bool clearing = true)
        {
            if(clearing)
                Clear(to);
                                    
            Goto(from);
            _code.Append('[');
            Goto(to);
            _code.Append(sign);
            Goto(from);
            _code.Append("-]");

        }

        private void Copy(int from, int to)
        {
            Move(from, _duplicatorPtr, '+');      // Перенесли значение в регистр D, указатель на from

            bool copyingToD = to == _duplicatorPtr;

            if (copyingToD)
            {
                Goto(_duplicatorBasePtr);   // Очищаем регистр Р
                _code.Append("[-]");
            }

            Goto(_duplicatorPtr);      // Указатель на регистре D
            _code.Append('[');              

            Goto(from);                // Возвращаем значение туда, откуда взяли
            _code.Append('+');

            Goto(copyingToD ? _duplicatorBasePtr : to);     // Заодно переносим в нужное место
            _code.Append('+');

            Goto(_duplicatorPtr);
            _code.Append("-]");

            if (copyingToD)
            {
                Move(_duplicatorBasePtr, _duplicatorPtr, '+');
            }
        }


        /// <summary>
        /// Переводит указатель на выбранную позицию.
        /// </summary>
        /// <param name="pos">Позиция перевода.</param>
        private void Goto(int pos)
        {
            while (_innerPtr < pos)
                Ptr++;

            while (_innerPtr > pos)
                Ptr--;
        }


        private void Clear(int where)
        {
            Goto(where);
            _code.Append("[-]");
        }

        private void ZeroPowerMath(int amount, char symbol)
        {
            for (int i = 0; i < amount; i++)
            {
                _code.Append(symbol);
            }
        }


    }
}
