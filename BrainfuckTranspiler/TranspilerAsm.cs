using System;

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
        


        private void LoadToAccumulator(string text)
        {
            Clear(_accumulatorPtr);
            if (_varTable.ContainsKey(text))
            {
                Copy(_varTable[text], _accumulatorPtr);
            }
            else
            {
                int amount = int.Parse(text);
                for (int i = 0; i < amount; i++)
                    _code.Append('+');
            }
        }

        private void LoadToBase(string text)
        {
            Clear(_basePtr);
            if (_varTable.ContainsKey(text))
            {
                Copy(_varTable[text], _basePtr);
            }
            else
            {
                int amount = int.Parse(text);
                for (int i = 0; i < amount; i++)
                {
                    _code.Append('+');
                }
            }

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
    }
}
