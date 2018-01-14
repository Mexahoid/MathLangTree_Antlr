using System;
using System.Collections.Generic;
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

        private const int Size = 30000;

        /// <summary>
        /// Указывает на последний индекс, принадлежащий переменной
        /// </summary>
        private int _varPtr;

        // |v|a|r|s|D|S|A|B|G1|G2|C1|C2|..|CN|<...>|L1|IT|IV|II|IH|IG1|IG2|EF2|ET2|EF1|ET1|EF0|ET0|
        // D - Duplicator
        // S - Summator/Substractor
        // A - Accumulator
        // B - Base
        // EM - Equator False
        // EH - Equator True
        // CN - Collector
        // G1, G2 - General purpose
        // IT - Threshold
        // IV - Value
        // II - Inequality
        // IH - Helper
        // IG1, IG2 - General purpose
        // LN - Loop

        private int _innerPtr;
        /// <summary>
        /// Начало секции удвоения
        /// </summary>
        private int _duplicatorPtr;
        private int _summatorPtr;
        private int _accumulatorPtr;
        private int _basePtr;
        private int _generalPtr;
        private int _collectorPtr;
        private int _loopPtr;
        private int _loopsInRow;
        private int _ifsInRow;

        public Transpiler(AstNode node)
        {
            _blockNode = node;
            _varTable = new Dictionary<string, int>();
            _reserved = new List<string>
            {
                "BLOCK", "=", "input", "print", "-", "+", "*", "/", "==", "<>", "if",
                ">", "<", ">=", "<=", "while", "for"
            };
            _code = new StringBuilder();
            _operationsQueue = new Queue<AstNode>();
        }


        public string Transpile()
        {
            int offset = 0;
            for (int i = 0; i < _blockNode.ChildCount; i++)
            {
                Analyze(_blockNode.GetChild(i), ref offset);
            }

            _summatorPtr = _duplicatorPtr + 1;      // S после D
            _accumulatorPtr = _summatorPtr + 1;     // A после S
            _basePtr = _accumulatorPtr + 1;         // И т.д., пока губы как у старой
            _generalPtr = _basePtr + 1;             // бабки не втянутся чтоб пиздец        
            _collectorPtr = _generalPtr + 2;        // и помереть нахуй
            _loopPtr = Size - offset;
            _ifsInRow = 0;


            //На этом моменте сформирована таблица переменных изначальных
            for (int i = 0; i < _blockNode.ChildCount; i++)
                ParseOperation(_blockNode.GetChild(i));
            _code.Append($"\n {_code.Length}");
            return _code.ToString();
        }

        private void Analyze(AstNode node, ref int offset)
        {
            if (_reserved.Contains(node.Text))
            {
                if (node.Text == "if" || node.Text == "while" || node.Text == "for")
                {
                    string op = node.Text == "for" ?
                        node.GetChild(1).Text : node.GetChild(0).Text;
                    switch (op)
                    {
                        case ">":
                        case "<":
                        case ">=":
                        case "<=":
                            offset += 6;
                            break;
                        case "==":
                        case "<>":
                            offset += 2;
                            break;
                    }
                }

                for (int i = 0; i < node.ChildCount; i++)
                    Analyze(node.GetChild(i), ref offset);
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
                    _ifsInRow++;
                    ProcessConditions(node);
                    break;
                case "while":
                case "for":
                    _loopsInRow++;
                    _ifsInRow++;
                    ProcessLoop(node);
                    break;
            }
        }
    }
}
