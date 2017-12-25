// $ANTLR 3.3 Nov 30, 2010 12:50:56 MathLang.g 2017-10-02 17:15:47

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

namespace  MathLang 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class MathLangLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int T__31=31;
	public const int T__32=32;
	public const int T__33=33;
	public const int T__34=34;
	public const int T__35=35;
	public const int T__36=36;
	public const int T__37=37;
	public const int UNKNOWN=4;
	public const int PRINT=5;
	public const int INPUT=6;
	public const int IF=7;
	public const int FOR=8;
	public const int FUNCTION=9;
	public const int RETURN=10;
	public const int WHILE=11;
	public const int BLOCK=12;
	public const int PROGRAM=13;
	public const int PARAMS=14;
	public const int WS=15;
	public const int SL_COMMENT=16;
	public const int ML_COMMENT=17;
	public const int NUMBER=18;
	public const int IDENT=19;
	public const int ADD=20;
	public const int SUB=21;
	public const int MUL=22;
	public const int DIV=23;
	public const int GE=24;
	public const int LE=25;
	public const int NEQUALS=26;
	public const int EQUALS=27;
	public const int GT=28;
	public const int LT=29;
	public const int ASSIGN=30;

    // delegates
    // delegators

	public MathLangLexer()
	{
		OnCreated();
	}

	public MathLangLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public MathLangLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "MathLang.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_PRINT();
	partial void Leave_PRINT();

	// $ANTLR start "PRINT"
	[GrammarRule("PRINT")]
	private void mPRINT()
	{
		Enter_PRINT();
		EnterRule("PRINT", 1);
		TraceIn("PRINT", 1);
		try
		{
			int _type = PRINT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:9:7: ( 'print' )
			DebugEnterAlt(1);
			// MathLang.g:9:9: 'print'
			{
			DebugLocation(9, 9);
			Match("print"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PRINT", 1);
			LeaveRule("PRINT", 1);
			Leave_PRINT();
		}
	}
	// $ANTLR end "PRINT"

	partial void Enter_INPUT();
	partial void Leave_INPUT();

	// $ANTLR start "INPUT"
	[GrammarRule("INPUT")]
	private void mINPUT()
	{
		Enter_INPUT();
		EnterRule("INPUT", 2);
		TraceIn("INPUT", 2);
		try
		{
			int _type = INPUT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:10:7: ( 'input' )
			DebugEnterAlt(1);
			// MathLang.g:10:9: 'input'
			{
			DebugLocation(10, 9);
			Match("input"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INPUT", 2);
			LeaveRule("INPUT", 2);
			Leave_INPUT();
		}
	}
	// $ANTLR end "INPUT"

	partial void Enter_IF();
	partial void Leave_IF();

	// $ANTLR start "IF"
	[GrammarRule("IF")]
	private void mIF()
	{
		Enter_IF();
		EnterRule("IF", 3);
		TraceIn("IF", 3);
		try
		{
			int _type = IF;
			int _channel = DefaultTokenChannel;
			// MathLang.g:11:4: ( 'if' )
			DebugEnterAlt(1);
			// MathLang.g:11:6: 'if'
			{
			DebugLocation(11, 6);
			Match("if"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IF", 3);
			LeaveRule("IF", 3);
			Leave_IF();
		}
	}
	// $ANTLR end "IF"

	partial void Enter_FOR();
	partial void Leave_FOR();

	// $ANTLR start "FOR"
	[GrammarRule("FOR")]
	private void mFOR()
	{
		Enter_FOR();
		EnterRule("FOR", 4);
		TraceIn("FOR", 4);
		try
		{
			int _type = FOR;
			int _channel = DefaultTokenChannel;
			// MathLang.g:12:5: ( 'for' )
			DebugEnterAlt(1);
			// MathLang.g:12:7: 'for'
			{
			DebugLocation(12, 7);
			Match("for"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FOR", 4);
			LeaveRule("FOR", 4);
			Leave_FOR();
		}
	}
	// $ANTLR end "FOR"

	partial void Enter_FUNCTION();
	partial void Leave_FUNCTION();

	// $ANTLR start "FUNCTION"
	[GrammarRule("FUNCTION")]
	private void mFUNCTION()
	{
		Enter_FUNCTION();
		EnterRule("FUNCTION", 5);
		TraceIn("FUNCTION", 5);
		try
		{
			int _type = FUNCTION;
			int _channel = DefaultTokenChannel;
			// MathLang.g:13:10: ( 'function' )
			DebugEnterAlt(1);
			// MathLang.g:13:12: 'function'
			{
			DebugLocation(13, 12);
			Match("function"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FUNCTION", 5);
			LeaveRule("FUNCTION", 5);
			Leave_FUNCTION();
		}
	}
	// $ANTLR end "FUNCTION"

	partial void Enter_RETURN();
	partial void Leave_RETURN();

	// $ANTLR start "RETURN"
	[GrammarRule("RETURN")]
	private void mRETURN()
	{
		Enter_RETURN();
		EnterRule("RETURN", 6);
		TraceIn("RETURN", 6);
		try
		{
			int _type = RETURN;
			int _channel = DefaultTokenChannel;
			// MathLang.g:14:8: ( 'return' )
			DebugEnterAlt(1);
			// MathLang.g:14:10: 'return'
			{
			DebugLocation(14, 10);
			Match("return"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RETURN", 6);
			LeaveRule("RETURN", 6);
			Leave_RETURN();
		}
	}
	// $ANTLR end "RETURN"

	partial void Enter_WHILE();
	partial void Leave_WHILE();

	// $ANTLR start "WHILE"
	[GrammarRule("WHILE")]
	private void mWHILE()
	{
		Enter_WHILE();
		EnterRule("WHILE", 7);
		TraceIn("WHILE", 7);
		try
		{
			int _type = WHILE;
			int _channel = DefaultTokenChannel;
			// MathLang.g:15:7: ( 'while' )
			DebugEnterAlt(1);
			// MathLang.g:15:9: 'while'
			{
			DebugLocation(15, 9);
			Match("while"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WHILE", 7);
			LeaveRule("WHILE", 7);
			Leave_WHILE();
		}
	}
	// $ANTLR end "WHILE"

	partial void Enter_T__31();
	partial void Leave_T__31();

	// $ANTLR start "T__31"
	[GrammarRule("T__31")]
	private void mT__31()
	{
		Enter_T__31();
		EnterRule("T__31", 8);
		TraceIn("T__31", 8);
		try
		{
			int _type = T__31;
			int _channel = DefaultTokenChannel;
			// MathLang.g:16:7: ( '(' )
			DebugEnterAlt(1);
			// MathLang.g:16:9: '('
			{
			DebugLocation(16, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__31", 8);
			LeaveRule("T__31", 8);
			Leave_T__31();
		}
	}
	// $ANTLR end "T__31"

	partial void Enter_T__32();
	partial void Leave_T__32();

	// $ANTLR start "T__32"
	[GrammarRule("T__32")]
	private void mT__32()
	{
		Enter_T__32();
		EnterRule("T__32", 9);
		TraceIn("T__32", 9);
		try
		{
			int _type = T__32;
			int _channel = DefaultTokenChannel;
			// MathLang.g:17:7: ( ')' )
			DebugEnterAlt(1);
			// MathLang.g:17:9: ')'
			{
			DebugLocation(17, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__32", 9);
			LeaveRule("T__32", 9);
			Leave_T__32();
		}
	}
	// $ANTLR end "T__32"

	partial void Enter_T__33();
	partial void Leave_T__33();

	// $ANTLR start "T__33"
	[GrammarRule("T__33")]
	private void mT__33()
	{
		Enter_T__33();
		EnterRule("T__33", 10);
		TraceIn("T__33", 10);
		try
		{
			int _type = T__33;
			int _channel = DefaultTokenChannel;
			// MathLang.g:18:7: ( ',' )
			DebugEnterAlt(1);
			// MathLang.g:18:9: ','
			{
			DebugLocation(18, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__33", 10);
			LeaveRule("T__33", 10);
			Leave_T__33();
		}
	}
	// $ANTLR end "T__33"

	partial void Enter_T__34();
	partial void Leave_T__34();

	// $ANTLR start "T__34"
	[GrammarRule("T__34")]
	private void mT__34()
	{
		Enter_T__34();
		EnterRule("T__34", 11);
		TraceIn("T__34", 11);
		try
		{
			int _type = T__34;
			int _channel = DefaultTokenChannel;
			// MathLang.g:19:7: ( '{' )
			DebugEnterAlt(1);
			// MathLang.g:19:9: '{'
			{
			DebugLocation(19, 9);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__34", 11);
			LeaveRule("T__34", 11);
			Leave_T__34();
		}
	}
	// $ANTLR end "T__34"

	partial void Enter_T__35();
	partial void Leave_T__35();

	// $ANTLR start "T__35"
	[GrammarRule("T__35")]
	private void mT__35()
	{
		Enter_T__35();
		EnterRule("T__35", 12);
		TraceIn("T__35", 12);
		try
		{
			int _type = T__35;
			int _channel = DefaultTokenChannel;
			// MathLang.g:20:7: ( '}' )
			DebugEnterAlt(1);
			// MathLang.g:20:9: '}'
			{
			DebugLocation(20, 9);
			Match('}'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__35", 12);
			LeaveRule("T__35", 12);
			Leave_T__35();
		}
	}
	// $ANTLR end "T__35"

	partial void Enter_T__36();
	partial void Leave_T__36();

	// $ANTLR start "T__36"
	[GrammarRule("T__36")]
	private void mT__36()
	{
		Enter_T__36();
		EnterRule("T__36", 13);
		TraceIn("T__36", 13);
		try
		{
			int _type = T__36;
			int _channel = DefaultTokenChannel;
			// MathLang.g:21:7: ( 'else' )
			DebugEnterAlt(1);
			// MathLang.g:21:9: 'else'
			{
			DebugLocation(21, 9);
			Match("else"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__36", 13);
			LeaveRule("T__36", 13);
			Leave_T__36();
		}
	}
	// $ANTLR end "T__36"

	partial void Enter_T__37();
	partial void Leave_T__37();

	// $ANTLR start "T__37"
	[GrammarRule("T__37")]
	private void mT__37()
	{
		Enter_T__37();
		EnterRule("T__37", 14);
		TraceIn("T__37", 14);
		try
		{
			int _type = T__37;
			int _channel = DefaultTokenChannel;
			// MathLang.g:22:7: ( ';' )
			DebugEnterAlt(1);
			// MathLang.g:22:9: ';'
			{
			DebugLocation(22, 9);
			Match(';'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__37", 14);
			LeaveRule("T__37", 14);
			Leave_T__37();
		}
	}
	// $ANTLR end "T__37"

	partial void Enter_WS();
	partial void Leave_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		Enter_WS();
		EnterRule("WS", 15);
		TraceIn("WS", 15);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// MathLang.g:31:3: ( ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+ )
			DebugEnterAlt(1);
			// MathLang.g:32:3: ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+
			{
			DebugLocation(32, 3);
			// MathLang.g:32:3: ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if (((LA1_0>='\t' && LA1_0<='\n')||(LA1_0>='\f' && LA1_0<='\r')||LA1_0==' '))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:
					{
					DebugLocation(32, 3);
					if ((input.LA(1)>='\t' && input.LA(1)<='\n')||(input.LA(1)>='\f' && input.LA(1)<='\r')||input.LA(1)==' ')
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(32, 41);

			    _channel=Hidden;
			  

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 15);
			LeaveRule("WS", 15);
			Leave_WS();
		}
	}
	// $ANTLR end "WS"

	partial void Enter_SL_COMMENT();
	partial void Leave_SL_COMMENT();

	// $ANTLR start "SL_COMMENT"
	[GrammarRule("SL_COMMENT")]
	private void mSL_COMMENT()
	{
		Enter_SL_COMMENT();
		EnterRule("SL_COMMENT", 16);
		TraceIn("SL_COMMENT", 16);
		try
		{
			int _type = SL_COMMENT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:37:11: ( '//' ( options {greedy=false; } : . )* ( '\\r' )? '\\n' )
			DebugEnterAlt(1);
			// MathLang.g:38:3: '//' ( options {greedy=false; } : . )* ( '\\r' )? '\\n'
			{
			DebugLocation(38, 3);
			Match("//"); 

			DebugLocation(38, 8);
			// MathLang.g:38:8: ( options {greedy=false; } : . )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if ((LA2_0=='\r'))
				{
					alt2=2;
				}
				else if ((LA2_0=='\n'))
				{
					alt2=2;
				}
				else if (((LA2_0>='\u0000' && LA2_0<='\t')||(LA2_0>='\u000B' && LA2_0<='\f')||(LA2_0>='\u000E' && LA2_0<='\uFFFF')))
				{
					alt2=1;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:38:36: .
					{
					DebugLocation(38, 36);
					MatchAny(); 

					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;

			} finally { DebugExitSubRule(2); }

			DebugLocation(38, 40);
			// MathLang.g:38:40: ( '\\r' )?
			int alt3=2;
			try { DebugEnterSubRule(3);
			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
			int LA3_0 = input.LA(1);

			if ((LA3_0=='\r'))
			{
				alt3=1;
			}
			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:38:40: '\\r'
				{
				DebugLocation(38, 40);
				Match('\r'); 

				}
				break;

			}
			} finally { DebugExitSubRule(3); }

			DebugLocation(38, 46);
			Match('\n'); 
			DebugLocation(38, 51);

			    _channel=Hidden;
			  

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SL_COMMENT", 16);
			LeaveRule("SL_COMMENT", 16);
			Leave_SL_COMMENT();
		}
	}
	// $ANTLR end "SL_COMMENT"

	partial void Enter_ML_COMMENT();
	partial void Leave_ML_COMMENT();

	// $ANTLR start "ML_COMMENT"
	[GrammarRule("ML_COMMENT")]
	private void mML_COMMENT()
	{
		Enter_ML_COMMENT();
		EnterRule("ML_COMMENT", 17);
		TraceIn("ML_COMMENT", 17);
		try
		{
			int _type = ML_COMMENT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:42:11: ( '/*' ( options {greedy=false; } : . )* '*/' )
			DebugEnterAlt(1);
			// MathLang.g:43:3: '/*' ( options {greedy=false; } : . )* '*/'
			{
			DebugLocation(43, 3);
			Match("/*"); 

			DebugLocation(43, 8);
			// MathLang.g:43:8: ( options {greedy=false; } : . )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

				if ((LA4_0=='*'))
				{
					int LA4_1 = input.LA(2);

					if ((LA4_1=='/'))
					{
						alt4=2;
					}
					else if (((LA4_1>='\u0000' && LA4_1<='.')||(LA4_1>='0' && LA4_1<='\uFFFF')))
					{
						alt4=1;
					}


				}
				else if (((LA4_0>='\u0000' && LA4_0<=')')||(LA4_0>='+' && LA4_0<='\uFFFF')))
				{
					alt4=1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:43:36: .
					{
					DebugLocation(43, 36);
					MatchAny(); 

					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(43, 40);
			Match("*/"); 

			DebugLocation(43, 45);

			    _channel=Hidden;
			  

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ML_COMMENT", 17);
			LeaveRule("ML_COMMENT", 17);
			Leave_ML_COMMENT();
		}
	}
	// $ANTLR end "ML_COMMENT"

	partial void Enter_NUMBER();
	partial void Leave_NUMBER();

	// $ANTLR start "NUMBER"
	[GrammarRule("NUMBER")]
	private void mNUMBER()
	{
		Enter_NUMBER();
		EnterRule("NUMBER", 18);
		TraceIn("NUMBER", 18);
		try
		{
			int _type = NUMBER;
			int _channel = DefaultTokenChannel;
			// MathLang.g:50:7: ( ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )? )
			DebugEnterAlt(1);
			// MathLang.g:50:9: ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )?
			{
			DebugLocation(50, 9);
			// MathLang.g:50:9: ( '0' .. '9' )+
			int cnt5=0;
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				int LA5_0 = input.LA(1);

				if (((LA5_0>='0' && LA5_0<='9')))
				{
					alt5=1;
				}


				} finally { DebugExitDecision(5); }
				switch (alt5)
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:50:10: '0' .. '9'
					{
					DebugLocation(50, 10);
					MatchRange('0','9'); 

					}
					break;

				default:
					if (cnt5 >= 1)
						goto loop5;

					EarlyExitException eee5 = new EarlyExitException( 5, input );
					DebugRecognitionException(eee5);
					throw eee5;
				}
				cnt5++;
			}
			loop5:
				;

			} finally { DebugExitSubRule(5); }

			DebugLocation(50, 21);
			// MathLang.g:50:21: ( '.' ( '0' .. '9' )+ )?
			int alt7=2;
			try { DebugEnterSubRule(7);
			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			int LA7_0 = input.LA(1);

			if ((LA7_0=='.'))
			{
				alt7=1;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:50:22: '.' ( '0' .. '9' )+
				{
				DebugLocation(50, 22);
				Match('.'); 
				DebugLocation(50, 26);
				// MathLang.g:50:26: ( '0' .. '9' )+
				int cnt6=0;
				try { DebugEnterSubRule(6);
				while (true)
				{
					int alt6=2;
					try { DebugEnterDecision(6, decisionCanBacktrack[6]);
					int LA6_0 = input.LA(1);

					if (((LA6_0>='0' && LA6_0<='9')))
					{
						alt6=1;
					}


					} finally { DebugExitDecision(6); }
					switch (alt6)
					{
					case 1:
						DebugEnterAlt(1);
						// MathLang.g:50:27: '0' .. '9'
						{
						DebugLocation(50, 27);
						MatchRange('0','9'); 

						}
						break;

					default:
						if (cnt6 >= 1)
							goto loop6;

						EarlyExitException eee6 = new EarlyExitException( 6, input );
						DebugRecognitionException(eee6);
						throw eee6;
					}
					cnt6++;
				}
				loop6:
					;

				} finally { DebugExitSubRule(6); }


				}
				break;

			}
			} finally { DebugExitSubRule(7); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NUMBER", 18);
			LeaveRule("NUMBER", 18);
			Leave_NUMBER();
		}
	}
	// $ANTLR end "NUMBER"

	partial void Enter_IDENT();
	partial void Leave_IDENT();

	// $ANTLR start "IDENT"
	[GrammarRule("IDENT")]
	private void mIDENT()
	{
		Enter_IDENT();
		EnterRule("IDENT", 19);
		TraceIn("IDENT", 19);
		try
		{
			int _type = IDENT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:52:6: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
			DebugEnterAlt(1);
			// MathLang.g:52:9: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
			{
			DebugLocation(52, 9);
			if ((input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(53, 9);
			// MathLang.g:53:9: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
			try { DebugEnterSubRule(8);
			while (true)
			{
				int alt8=2;
				try { DebugEnterDecision(8, decisionCanBacktrack[8]);
				int LA8_0 = input.LA(1);

				if (((LA8_0>='0' && LA8_0<='9')||(LA8_0>='A' && LA8_0<='Z')||LA8_0=='_'||(LA8_0>='a' && LA8_0<='z')))
				{
					alt8=1;
				}


				} finally { DebugExitDecision(8); }
				switch ( alt8 )
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:
					{
					DebugLocation(53, 9);
					if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					goto loop8;
				}
			}

			loop8:
				;

			} finally { DebugExitSubRule(8); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IDENT", 19);
			LeaveRule("IDENT", 19);
			Leave_IDENT();
		}
	}
	// $ANTLR end "IDENT"

	partial void Enter_ADD();
	partial void Leave_ADD();

	// $ANTLR start "ADD"
	[GrammarRule("ADD")]
	private void mADD()
	{
		Enter_ADD();
		EnterRule("ADD", 20);
		TraceIn("ADD", 20);
		try
		{
			int _type = ADD;
			int _channel = DefaultTokenChannel;
			// MathLang.g:55:4: ( '+' )
			DebugEnterAlt(1);
			// MathLang.g:55:9: '+'
			{
			DebugLocation(55, 9);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ADD", 20);
			LeaveRule("ADD", 20);
			Leave_ADD();
		}
	}
	// $ANTLR end "ADD"

	partial void Enter_SUB();
	partial void Leave_SUB();

	// $ANTLR start "SUB"
	[GrammarRule("SUB")]
	private void mSUB()
	{
		Enter_SUB();
		EnterRule("SUB", 21);
		TraceIn("SUB", 21);
		try
		{
			int _type = SUB;
			int _channel = DefaultTokenChannel;
			// MathLang.g:56:4: ( '-' )
			DebugEnterAlt(1);
			// MathLang.g:56:9: '-'
			{
			DebugLocation(56, 9);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUB", 21);
			LeaveRule("SUB", 21);
			Leave_SUB();
		}
	}
	// $ANTLR end "SUB"

	partial void Enter_MUL();
	partial void Leave_MUL();

	// $ANTLR start "MUL"
	[GrammarRule("MUL")]
	private void mMUL()
	{
		Enter_MUL();
		EnterRule("MUL", 22);
		TraceIn("MUL", 22);
		try
		{
			int _type = MUL;
			int _channel = DefaultTokenChannel;
			// MathLang.g:57:4: ( '*' )
			DebugEnterAlt(1);
			// MathLang.g:57:9: '*'
			{
			DebugLocation(57, 9);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MUL", 22);
			LeaveRule("MUL", 22);
			Leave_MUL();
		}
	}
	// $ANTLR end "MUL"

	partial void Enter_DIV();
	partial void Leave_DIV();

	// $ANTLR start "DIV"
	[GrammarRule("DIV")]
	private void mDIV()
	{
		Enter_DIV();
		EnterRule("DIV", 23);
		TraceIn("DIV", 23);
		try
		{
			int _type = DIV;
			int _channel = DefaultTokenChannel;
			// MathLang.g:58:4: ( '/' )
			DebugEnterAlt(1);
			// MathLang.g:58:9: '/'
			{
			DebugLocation(58, 9);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DIV", 23);
			LeaveRule("DIV", 23);
			Leave_DIV();
		}
	}
	// $ANTLR end "DIV"

	partial void Enter_GE();
	partial void Leave_GE();

	// $ANTLR start "GE"
	[GrammarRule("GE")]
	private void mGE()
	{
		Enter_GE();
		EnterRule("GE", 24);
		TraceIn("GE", 24);
		try
		{
			int _type = GE;
			int _channel = DefaultTokenChannel;
			// MathLang.g:60:3: ( '>=' )
			DebugEnterAlt(1);
			// MathLang.g:60:11: '>='
			{
			DebugLocation(60, 11);
			Match(">="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GE", 24);
			LeaveRule("GE", 24);
			Leave_GE();
		}
	}
	// $ANTLR end "GE"

	partial void Enter_LE();
	partial void Leave_LE();

	// $ANTLR start "LE"
	[GrammarRule("LE")]
	private void mLE()
	{
		Enter_LE();
		EnterRule("LE", 25);
		TraceIn("LE", 25);
		try
		{
			int _type = LE;
			int _channel = DefaultTokenChannel;
			// MathLang.g:61:3: ( '<=' )
			DebugEnterAlt(1);
			// MathLang.g:61:11: '<='
			{
			DebugLocation(61, 11);
			Match("<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LE", 25);
			LeaveRule("LE", 25);
			Leave_LE();
		}
	}
	// $ANTLR end "LE"

	partial void Enter_NEQUALS();
	partial void Leave_NEQUALS();

	// $ANTLR start "NEQUALS"
	[GrammarRule("NEQUALS")]
	private void mNEQUALS()
	{
		Enter_NEQUALS();
		EnterRule("NEQUALS", 26);
		TraceIn("NEQUALS", 26);
		try
		{
			int _type = NEQUALS;
			int _channel = DefaultTokenChannel;
			// MathLang.g:62:8: ( '<>' )
			DebugEnterAlt(1);
			// MathLang.g:62:11: '<>'
			{
			DebugLocation(62, 11);
			Match("<>"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NEQUALS", 26);
			LeaveRule("NEQUALS", 26);
			Leave_NEQUALS();
		}
	}
	// $ANTLR end "NEQUALS"

	partial void Enter_EQUALS();
	partial void Leave_EQUALS();

	// $ANTLR start "EQUALS"
	[GrammarRule("EQUALS")]
	private void mEQUALS()
	{
		Enter_EQUALS();
		EnterRule("EQUALS", 27);
		TraceIn("EQUALS", 27);
		try
		{
			int _type = EQUALS;
			int _channel = DefaultTokenChannel;
			// MathLang.g:63:7: ( '==' )
			DebugEnterAlt(1);
			// MathLang.g:63:11: '=='
			{
			DebugLocation(63, 11);
			Match("=="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EQUALS", 27);
			LeaveRule("EQUALS", 27);
			Leave_EQUALS();
		}
	}
	// $ANTLR end "EQUALS"

	partial void Enter_GT();
	partial void Leave_GT();

	// $ANTLR start "GT"
	[GrammarRule("GT")]
	private void mGT()
	{
		Enter_GT();
		EnterRule("GT", 28);
		TraceIn("GT", 28);
		try
		{
			int _type = GT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:64:3: ( '>' )
			DebugEnterAlt(1);
			// MathLang.g:64:11: '>'
			{
			DebugLocation(64, 11);
			Match('>'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GT", 28);
			LeaveRule("GT", 28);
			Leave_GT();
		}
	}
	// $ANTLR end "GT"

	partial void Enter_LT();
	partial void Leave_LT();

	// $ANTLR start "LT"
	[GrammarRule("LT")]
	private void mLT()
	{
		Enter_LT();
		EnterRule("LT", 29);
		TraceIn("LT", 29);
		try
		{
			int _type = LT;
			int _channel = DefaultTokenChannel;
			// MathLang.g:65:3: ( '<' )
			DebugEnterAlt(1);
			// MathLang.g:65:11: '<'
			{
			DebugLocation(65, 11);
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LT", 29);
			LeaveRule("LT", 29);
			Leave_LT();
		}
	}
	// $ANTLR end "LT"

	partial void Enter_ASSIGN();
	partial void Leave_ASSIGN();

	// $ANTLR start "ASSIGN"
	[GrammarRule("ASSIGN")]
	private void mASSIGN()
	{
		Enter_ASSIGN();
		EnterRule("ASSIGN", 30);
		TraceIn("ASSIGN", 30);
		try
		{
			int _type = ASSIGN;
			int _channel = DefaultTokenChannel;
			// MathLang.g:67:7: ( '=' )
			DebugEnterAlt(1);
			// MathLang.g:67:9: '='
			{
			DebugLocation(67, 9);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ASSIGN", 30);
			LeaveRule("ASSIGN", 30);
			Leave_ASSIGN();
		}
	}
	// $ANTLR end "ASSIGN"

	public override void mTokens()
	{
		// MathLang.g:1:8: ( PRINT | INPUT | IF | FOR | FUNCTION | RETURN | WHILE | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | WS | SL_COMMENT | ML_COMMENT | NUMBER | IDENT | ADD | SUB | MUL | DIV | GE | LE | NEQUALS | EQUALS | GT | LT | ASSIGN )
		int alt9=30;
		try { DebugEnterDecision(9, decisionCanBacktrack[9]);
		try
		{
			alt9 = dfa9.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(9); }
		switch (alt9)
		{
		case 1:
			DebugEnterAlt(1);
			// MathLang.g:1:10: PRINT
			{
			DebugLocation(1, 10);
			mPRINT(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// MathLang.g:1:16: INPUT
			{
			DebugLocation(1, 16);
			mINPUT(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// MathLang.g:1:22: IF
			{
			DebugLocation(1, 22);
			mIF(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// MathLang.g:1:25: FOR
			{
			DebugLocation(1, 25);
			mFOR(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// MathLang.g:1:29: FUNCTION
			{
			DebugLocation(1, 29);
			mFUNCTION(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// MathLang.g:1:38: RETURN
			{
			DebugLocation(1, 38);
			mRETURN(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// MathLang.g:1:45: WHILE
			{
			DebugLocation(1, 45);
			mWHILE(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// MathLang.g:1:51: T__31
			{
			DebugLocation(1, 51);
			mT__31(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// MathLang.g:1:57: T__32
			{
			DebugLocation(1, 57);
			mT__32(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// MathLang.g:1:63: T__33
			{
			DebugLocation(1, 63);
			mT__33(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// MathLang.g:1:69: T__34
			{
			DebugLocation(1, 69);
			mT__34(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// MathLang.g:1:75: T__35
			{
			DebugLocation(1, 75);
			mT__35(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// MathLang.g:1:81: T__36
			{
			DebugLocation(1, 81);
			mT__36(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// MathLang.g:1:87: T__37
			{
			DebugLocation(1, 87);
			mT__37(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// MathLang.g:1:93: WS
			{
			DebugLocation(1, 93);
			mWS(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// MathLang.g:1:96: SL_COMMENT
			{
			DebugLocation(1, 96);
			mSL_COMMENT(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// MathLang.g:1:107: ML_COMMENT
			{
			DebugLocation(1, 107);
			mML_COMMENT(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// MathLang.g:1:118: NUMBER
			{
			DebugLocation(1, 118);
			mNUMBER(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// MathLang.g:1:125: IDENT
			{
			DebugLocation(1, 125);
			mIDENT(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// MathLang.g:1:131: ADD
			{
			DebugLocation(1, 131);
			mADD(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// MathLang.g:1:135: SUB
			{
			DebugLocation(1, 135);
			mSUB(); 

			}
			break;
		case 22:
			DebugEnterAlt(22);
			// MathLang.g:1:139: MUL
			{
			DebugLocation(1, 139);
			mMUL(); 

			}
			break;
		case 23:
			DebugEnterAlt(23);
			// MathLang.g:1:143: DIV
			{
			DebugLocation(1, 143);
			mDIV(); 

			}
			break;
		case 24:
			DebugEnterAlt(24);
			// MathLang.g:1:147: GE
			{
			DebugLocation(1, 147);
			mGE(); 

			}
			break;
		case 25:
			DebugEnterAlt(25);
			// MathLang.g:1:150: LE
			{
			DebugLocation(1, 150);
			mLE(); 

			}
			break;
		case 26:
			DebugEnterAlt(26);
			// MathLang.g:1:153: NEQUALS
			{
			DebugLocation(1, 153);
			mNEQUALS(); 

			}
			break;
		case 27:
			DebugEnterAlt(27);
			// MathLang.g:1:161: EQUALS
			{
			DebugLocation(1, 161);
			mEQUALS(); 

			}
			break;
		case 28:
			DebugEnterAlt(28);
			// MathLang.g:1:168: GT
			{
			DebugLocation(1, 168);
			mGT(); 

			}
			break;
		case 29:
			DebugEnterAlt(29);
			// MathLang.g:1:171: LT
			{
			DebugLocation(1, 171);
			mLT(); 

			}
			break;
		case 30:
			DebugEnterAlt(30);
			// MathLang.g:1:174: ASSIGN
			{
			DebugLocation(1, 174);
			mASSIGN(); 

			}
			break;

		}

	}


	#region DFA
	DFA9 dfa9;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa9 = new DFA9(this);
	}

	private class DFA9 : DFA
	{
		private const string DFA9_eotS =
			"\x1\xFFFF\x5\x10\x5\xFFFF\x1\x10\x2\xFFFF\x1\x21\x5\xFFFF\x1\x23\x1"+
			"\x26\x1\x28\x2\x10\x1\x2B\x5\x10\xA\xFFFF\x2\x10\x1\xFFFF\x1\x33\x6\x10"+
			"\x1\xFFFF\x3\x10\x1\x3D\x1\x3E\x1\x3F\x2\x10\x1\x42\x3\xFFFF\x1\x10\x1"+
			"\x44\x1\xFFFF\x1\x10\x1\xFFFF\x1\x46\x1\xFFFF";
		private const string DFA9_eofS =
			"\x47\xFFFF";
		private const string DFA9_minS =
			"\x1\x9\x1\x72\x1\x66\x1\x6F\x1\x65\x1\x68\x5\xFFFF\x1\x6C\x2\xFFFF\x1"+
			"\x2A\x5\xFFFF\x3\x3D\x1\x69\x1\x70\x1\x30\x1\x72\x1\x6E\x1\x74\x1\x69"+
			"\x1\x73\xA\xFFFF\x1\x6E\x1\x75\x1\xFFFF\x1\x30\x1\x63\x1\x75\x1\x6C\x1"+
			"\x65\x2\x74\x1\xFFFF\x1\x74\x1\x72\x1\x65\x3\x30\x1\x69\x1\x6E\x1\x30"+
			"\x3\xFFFF\x1\x6F\x1\x30\x1\xFFFF\x1\x6E\x1\xFFFF\x1\x30\x1\xFFFF";
		private const string DFA9_maxS =
			"\x1\x7D\x1\x72\x1\x6E\x1\x75\x1\x65\x1\x68\x5\xFFFF\x1\x6C\x2\xFFFF"+
			"\x1\x2F\x5\xFFFF\x1\x3D\x1\x3E\x1\x3D\x1\x69\x1\x70\x1\x7A\x1\x72\x1"+
			"\x6E\x1\x74\x1\x69\x1\x73\xA\xFFFF\x1\x6E\x1\x75\x1\xFFFF\x1\x7A\x1\x63"+
			"\x1\x75\x1\x6C\x1\x65\x2\x74\x1\xFFFF\x1\x74\x1\x72\x1\x65\x3\x7A\x1"+
			"\x69\x1\x6E\x1\x7A\x3\xFFFF\x1\x6F\x1\x7A\x1\xFFFF\x1\x6E\x1\xFFFF\x1"+
			"\x7A\x1\xFFFF";
		private const string DFA9_acceptS =
			"\x6\xFFFF\x1\x8\x1\x9\x1\xA\x1\xB\x1\xC\x1\xFFFF\x1\xE\x1\xF\x1\xFFFF"+
			"\x1\x12\x1\x13\x1\x14\x1\x15\x1\x16\xB\xFFFF\x1\x10\x1\x11\x1\x17\x1"+
			"\x18\x1\x1C\x1\x19\x1\x1A\x1\x1D\x1\x1B\x1\x1E\x2\xFFFF\x1\x3\x7\xFFFF"+
			"\x1\x4\x9\xFFFF\x1\xD\x1\x1\x1\x2\x2\xFFFF\x1\x7\x1\xFFFF\x1\x6\x1\xFFFF"+
			"\x1\x5";
		private const string DFA9_specialS =
			"\x47\xFFFF}>";
		private static readonly string[] DFA9_transitionS =
			{
				"\x2\xD\x1\xFFFF\x2\xD\x12\xFFFF\x1\xD\x7\xFFFF\x1\x6\x1\x7\x1\x13\x1"+
				"\x11\x1\x8\x1\x12\x1\xFFFF\x1\xE\xA\xF\x1\xFFFF\x1\xC\x1\x15\x1\x16"+
				"\x1\x14\x2\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x4\x10\x1\xB\x1\x3"+
				"\x2\x10\x1\x2\x6\x10\x1\x1\x1\x10\x1\x4\x4\x10\x1\x5\x3\x10\x1\x9\x1"+
				"\xFFFF\x1\xA",
				"\x1\x17",
				"\x1\x19\x7\xFFFF\x1\x18",
				"\x1\x1A\x5\xFFFF\x1\x1B",
				"\x1\x1C",
				"\x1\x1D",
				"",
				"",
				"",
				"",
				"",
				"\x1\x1E",
				"",
				"",
				"\x1\x20\x4\xFFFF\x1\x1F",
				"",
				"",
				"",
				"",
				"",
				"\x1\x22",
				"\x1\x24\x1\x25",
				"\x1\x27",
				"\x1\x29",
				"\x1\x2A",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"\x1\x2C",
				"\x1\x2D",
				"\x1\x2E",
				"\x1\x2F",
				"\x1\x30",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x31",
				"\x1\x32",
				"",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"\x1\x34",
				"\x1\x35",
				"\x1\x36",
				"\x1\x37",
				"\x1\x38",
				"\x1\x39",
				"",
				"\x1\x3A",
				"\x1\x3B",
				"\x1\x3C",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"\x1\x40",
				"\x1\x41",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"",
				"",
				"",
				"\x1\x43",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				"",
				"\x1\x45",
				"",
				"\xA\x10\x7\xFFFF\x1A\x10\x4\xFFFF\x1\x10\x1\xFFFF\x1A\x10",
				""
			};

		private static readonly short[] DFA9_eot = DFA.UnpackEncodedString(DFA9_eotS);
		private static readonly short[] DFA9_eof = DFA.UnpackEncodedString(DFA9_eofS);
		private static readonly char[] DFA9_min = DFA.UnpackEncodedStringToUnsignedChars(DFA9_minS);
		private static readonly char[] DFA9_max = DFA.UnpackEncodedStringToUnsignedChars(DFA9_maxS);
		private static readonly short[] DFA9_accept = DFA.UnpackEncodedString(DFA9_acceptS);
		private static readonly short[] DFA9_special = DFA.UnpackEncodedString(DFA9_specialS);
		private static readonly short[][] DFA9_transition;

		static DFA9()
		{
			int numStates = DFA9_transitionS.Length;
			DFA9_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA9_transition[i] = DFA.UnpackEncodedString(DFA9_transitionS[i]);
			}
		}

		public DFA9( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 9;
			this.eot = DFA9_eot;
			this.eof = DFA9_eof;
			this.min = DFA9_min;
			this.max = DFA9_max;
			this.accept = DFA9_accept;
			this.special = DFA9_special;
			this.transition = DFA9_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( PRINT | INPUT | IF | FOR | FUNCTION | RETURN | WHILE | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | WS | SL_COMMENT | ML_COMMENT | NUMBER | IDENT | ADD | SUB | MUL | DIV | GE | LE | NEQUALS | EQUALS | GT | LT | ASSIGN );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}

} // namespace  MathLang 
