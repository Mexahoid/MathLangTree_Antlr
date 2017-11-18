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

        private int _innerPtr;
        /// <summary>
        /// Начало секции удвоения
        /// </summary>
        private int _setterPtr;
        private int _varPtr;
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
            _reserved = new List<string> { "BLOCK", "=", "input", "print" };
            _code = new StringBuilder();
        }


        public string Transpile()
        {
            for (int i = 0; i < _blockNode.ChildCount; i++)
                FindVars(_blockNode.GetChild(i));
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
                _setterPtr++;
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
            }
        }


        private void ProcessEquality(AstNode node)
        {
            AstNode var2 = node.GetChild(1);

            bool isVariable = !int.TryParse(var2.Text, out int value);
            //Просто проверка на дебила
            if (isVariable)
                if (!_varTable.ContainsKey(var2.Text))
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

            while (_innerPtr < _varTable[var1.Text])
                Ptr++;

            while (_innerPtr > _varTable[var1.Text])
                Ptr--;

            int.TryParse(var2.Text, out int value);
            _code.Append("[-]");
            //if (value > _varValues[var1.Text])
            for (int i = 0; i < value; i++)
                _code.Append('+');
            /*else if (value < _varValues[var1.Text])
                for (int i = 0; i < _varValues[var1.Text] - value; i++)
                    _code.Append('-');*/
            //_varValues[var1.Text] = value;

        }

        private void ProcessVariableEquality(AstNode node)
        {
            AstNode var1 = node.GetChild(0);
            AstNode var2 = node.GetChild(1);

            int pos1 = _varTable[var1.Text];
            int pos2 = _varTable[var2.Text];

            //Передвигаем указатель на позицию присваиваемой переменной
            while (_innerPtr < pos2)
                Ptr++;

            while (_innerPtr > pos2)
                Ptr--;

            //Перенос значения в ячейку дублирования
            //Начинаем разрушающий цикл
            _code.Append('[');
            while (_innerPtr < _setterPtr)
                Ptr++;
            _code.Append('+');
            while (_innerPtr > pos2)
                Ptr--;
            _code.Append("-]");
            //В ячейке _setterPtr содержится значение второй переменной

            //Переводим указатель на первую переменную
            while (_innerPtr < pos1)
                Ptr++;

            while (_innerPtr > pos1)
                Ptr--;
            _code.Append("[-]");  //Устанавливаем 0 на переменной 1

            //Переходим обратно на ячейку дублирования
            while (_innerPtr < _setterPtr)
                Ptr++;

            _code.Append('[');  //Начинаем разрушающий цикл

            int left = Math.Min(pos1, pos2);
            int right = Math.Max(pos1, pos2);
            //Сдвигаемся на правую переменную
            while (_innerPtr > right)
                Ptr--;
            _code.Append('+');
            //Сдвигаемся на левую переменную
            while (_innerPtr > left)
                Ptr--;
            _code.Append('+');
            //Переходим обратно на ячейку дублирования
            while (_innerPtr < _setterPtr)
                Ptr++;
            _code.Append("-]");
        }

        private void ProcessPrint(AstNode node)
        {
            AstNode var = node.GetChild(0);
            while (_innerPtr < _varTable[var.Text])
                Ptr++;

            while (_innerPtr > _varTable[var.Text])
                Ptr--;

            _code.Append('.');
        }

        private void ProcessInput(AstNode node)
        {
            AstNode var = node.GetChild(0);
            while (_innerPtr < _varTable[var.Text])
                Ptr++;

            while (_innerPtr > _varTable[var.Text])
                Ptr--;

            _code.Append(',');
        }
    }
}
