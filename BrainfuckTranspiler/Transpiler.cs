using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // |v|a|r|i|a|b|l|e|s|D|S|A|B
        // D - Duplicator
        // S - Summator/Substractor
        // A - Accumulator
        // B - Base


        private int _innerPtr;
        /// <summary>
        /// Начало секции удвоения
        /// </summary>
        private int _duplicatorPtr;
        private int _summatorPtr;
        private int _accumulatorPtr;
        private int _basePtr;

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
            _summatorPtr = _duplicatorPtr + 1;          // S после D
            _accumulatorPtr = _summatorPtr + 1;         // A после S
            _basePtr = _accumulatorPtr + 1;

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
            
            int.TryParse(var2.Text, out int value);
            if(value < 0)
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
                LoadValueToBase(value);               // Загрузили число в регистр В
                act(node.Text[0]);
                return;
            }

            // 10 + V или 10 - V
            if (!varIsVar && !valueIsValue)
            {
                LoadValueToAccumulator(var);               // Загрузили число в регистр В
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
        

        /// <summary>
        /// Выполняет операцию суммирования. Сначала загружает А в S, потом складывает или вычитает В с S
        /// </summary>
        /// <param name="sign">Знак операции.</param>
        private void Sum(char sign)
        {
            Move(_accumulatorPtr, _summatorPtr, '+');
            Move(_basePtr, _summatorPtr, sign, false);
        }

        private void Mult(char sign)
        {
            if(sign == '/')
                throw new NotImplementedException();

            Goto(_basePtr);
            _code.Append('[');
            Goto(_accumulatorPtr);
            _code.Append('[');
            Goto(_summatorPtr);
            _code.Append('+');
            Goto(_duplicatorPtr);
            _code.Append('+');
            Goto(_accumulatorPtr);
            _code.Append("-]");
            Goto(_duplicatorPtr);
            _code.Append('[');
            Goto(_accumulatorPtr);
            _code.Append('+');
            Goto(_duplicatorPtr);
            _code.Append("-]");
            Goto(_basePtr);
            _code.Append("-]");
        }

        
        /// <summary>
        /// Переносим значение из регистра D в нужную ячейку.
        /// </summary>
        /// <param name="from">Откуда переносим.</param>
        /// <param name="to">Куда переносим.</param>
        /// <param name="sign">Знак операции переноса.</param>
        /// <param name="clearing">Нужно ли очистить ячейку назначения.</param>
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

            Goto(_duplicatorPtr);      // Указатель на регистре D
            _code.Append('[');              

            Goto(from);                // Возвращаем значение туда, откуда взяли
            _code.Append('+');

            Goto(to);     // Заодно переносим в нужное место
            _code.Append('+');

            Goto(_duplicatorPtr);
            _code.Append("-]");
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

        /// <summary>
        /// Очищает ячейку по указателю.
        /// </summary>
        /// <param name="where">Указатель на ячейку.</param>
        private void Clear(int where)
        {
            Goto(where);
            _code.Append("[-]");
        }
        

        private void LoadValueToAccumulator(int amount)
        {
            Clear(_accumulatorPtr);
            for (int i = 0; i < amount; i++)
            {
                _code.Append('+');
            }
        }

        private void LoadValueToBase(int amount)
        {
            Clear(_basePtr);
            for (int i = 0; i < amount; i++)
            {
                _code.Append('+');
            }
        }

        private void LoadVariableToBase(int pointer)
        {
            Clear(_basePtr);
            Copy(pointer, _basePtr);
        }

        private void LoadVariableToAccumulator(int pointer)
        {
            Clear(_accumulatorPtr);
            Copy(pointer, _accumulatorPtr);
        }
    }
}
