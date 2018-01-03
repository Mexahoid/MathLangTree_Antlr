using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


using AstNode = Antlr.Runtime.Tree.ITree;

namespace BrainfuckTranspiler
{
    public partial class Transpiler
    {
        private readonly AstNode _blockNode;
        private readonly IDictionary<string, int> _varTable;
        private readonly IList<string> _reserved;

        private readonly StringBuilder _code;

        private readonly Queue<AstNode> _operationsQueue;

        /// <summary>
        /// Указывает на последний индекс, принадлежащий переменной
        /// </summary>
        private int _varPtr;

        // |v|a|r|i|a|b|l|e|s|D|S|A|B|EM|EH|C1|C2|..|CN|
        // D - Duplicator
        // S - Summator/Substractor
        // A - Accumulator
        // B - Base
        // EM - Equator Main
        // EH - Equator Helper
        // CN - Collector

        private int _innerPtr;
        /// <summary>
        /// Начало секции удвоения
        /// </summary>
        private int _duplicatorPtr;
        private int _summatorPtr;
        private int _accumulatorPtr;
        private int _basePtr;
        private int _equatorMainPtr;
        private int _equatorHelperPtr;
        private int _collectorPtr;
        private int _collectorSize;

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
            _reserved = new List<string> { "BLOCK", "=", "input", "print", "-", "+", "*", "/", "==", "<>", "if" };
            _code = new StringBuilder();
            _operationsQueue = new Queue<AstNode>();
        }


        public string Transpile()
        {
            for (int i = 0; i < _blockNode.ChildCount; i++)
                FindVars(_blockNode.GetChild(i));
            _summatorPtr = _duplicatorPtr + 1;          // S после D
            _accumulatorPtr = _summatorPtr + 1;         // A после S
            _basePtr = _accumulatorPtr + 1;
            _equatorMainPtr = _basePtr + 1;
            _equatorHelperPtr = _equatorMainPtr + 1;
            _collectorPtr = _equatorHelperPtr + 1;
            _collectorSize = 0;

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

            if (_varTable.ContainsKey(node.Text))
                return;

            _varTable.Add(node.Text, _varPtr++);
            _duplicatorPtr++;
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
                case "if":
                    ProcessConditionalEquality(node);
                    break;
            }
        }


    }
}
