using System;
using AstNode = Antlr.Runtime.Tree.ITree;

namespace BrainfuckTranspiler
{
    public partial class Transpiler
    {
        /// <summary>
        /// Выполняет операцию суммирования. Сначала загружает А в S, потом складывает или вычитает В с S
        /// </summary>
        /// <param name="sign">Знак операции.</param>
        private void Sum(char sign)
        {
            Move(_basePtr, _summatorPtr, '+');
            Move(_accumulatorPtr, _summatorPtr, sign, false);
        }

        private void Mult(char sign)
        {
            if (sign == '/')
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
            if (clearing)
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
            void Increment()
            {
                _innerPtr++;
                _code.Append('>');
            }

            void Decrement()
            {
                _innerPtr--;
                _code.Append('<');
            }
            if (pos == Size)
                throw new Exception("Ошибка параметра в Goto");

            if (pos < 15000 && _innerPtr < 15000 || pos >= 15000 && _innerPtr >= 15000)
            {
                while (_innerPtr < pos)
                    Increment();

                while (_innerPtr > pos)
                    Decrement();

            }
            else if (_innerPtr < 15000 && pos >= 15000)
            {
                while (_innerPtr != pos)
                {
                    Decrement();
                    // Если -1, то ставим в 29999
                    if (_innerPtr < 0)
                        _innerPtr = Size + _innerPtr;
                }
            }
            else if (_innerPtr >= 15000 && pos < 15000)
            {
                while (_innerPtr != pos)
                {
                    Increment();
                    // Если 30000, то ставим в 0
                    if (_innerPtr > 29999)
                        _innerPtr = 0;
                }
            }
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

        private void LoadToCollector(int from)
        {
            Move(from, _collectorPtr++, '+');
            _collectorSize++;
        }
        private void GetFromCollector(int where)
        {
            Move(--_collectorPtr, where, '+');
            _collectorSize--;
        }


        private void LoadToCollector(string text)
        {
            if (_varTable.ContainsKey(text))
            {
                Copy(_varTable[text], _collectorPtr);
            }
            else
            {
                Goto(_collectorPtr);
                int amount = int.Parse(text);
                for (int i = 0; i < amount; i++)
                    _code.Append('+');
            }
            _collectorPtr++;
            _collectorSize++;
        }


        private void InsertBlock(AstNode node)
        {
            if (node.Text == "if")
                ParseOperation(node);
            else
                for (int i = 0; i < node.ChildCount; i++)
                {
                    ParseOperation(node.GetChild(i));
                }
        }

    }
}
