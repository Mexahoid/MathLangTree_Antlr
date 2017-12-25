// $ANTLR 3.3 Nov 30, 2010 12:50:56 MathLang.g 2017-10-02 17:15:46

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;
using Map = System.Collections.IDictionary;
using HashMap = System.Collections.Generic.Dictionary<object, object>;

using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

namespace  MathLang 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class MathLangParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "UNKNOWN", "PRINT", "INPUT", "IF", "FOR", "FUNCTION", "RETURN", "WHILE", "BLOCK", "PROGRAM", "PARAMS", "WS", "SL_COMMENT", "ML_COMMENT", "NUMBER", "IDENT", "ADD", "SUB", "MUL", "DIV", "GE", "LE", "NEQUALS", "EQUALS", "GT", "LT", "ASSIGN", "'('", "')'", "','", "'{'", "'}'", "'else'", "';'"
	};
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

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false, false, true, false, 
				false, false, false, , , 
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public MathLangParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public MathLangParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		this.state.ruleMemo = new System.Collections.Generic.Dictionary<int, int>[40+1];

		ITreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor);

	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return MathLangParser.tokenNames; } }
	public override string GrammarFileName { get { return "MathLang.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class group_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_group();
	partial void Leave_group();

	// $ANTLR start "group"
	// MathLang.g:70:1: group : ( '(' term ')' | NUMBER | IDENT );
	[GrammarRule("group")]
	private MathLangParser.group_return group()
	{
		Enter_group();
		EnterRule("group", 1);
		TraceIn("group", 1);
		MathLangParser.group_return retval = new MathLangParser.group_return();
		retval.Start = (IToken)input.LT(1);
		int group_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal1=null;
		IToken char_literal3=null;
		IToken NUMBER4=null;
		IToken IDENT5=null;
		MathLangParser.term_return term2 = default(MathLangParser.term_return);

		object char_literal1_tree=null;
		object char_literal3_tree=null;
		object NUMBER4_tree=null;
		object IDENT5_tree=null;

		try { DebugEnterRule(GrammarFileName, "group");
		DebugLocation(70, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 1)) { return retval; }
			// MathLang.g:70:6: ( '(' term ')' | NUMBER | IDENT )
			int alt1=3;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			switch (input.LA(1))
			{
			case 31:
				{
				alt1=1;
				}
				break;
			case NUMBER:
				{
				alt1=2;
				}
				break;
			case IDENT:
				{
				alt1=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 1, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:71:3: '(' term ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(71, 6);
				char_literal1=(IToken)Match(input,31,Follow._31_in_group572); if (state.failed) return retval;
				DebugLocation(71, 8);
				PushFollow(Follow._term_in_group575);
				term2=term();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term2.Tree);
				DebugLocation(71, 16);
				char_literal3=(IToken)Match(input,32,Follow._32_in_group577); if (state.failed) return retval;

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// MathLang.g:72:3: NUMBER
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(72, 3);
				NUMBER4=(IToken)Match(input,NUMBER,Follow._NUMBER_in_group582); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				NUMBER4_tree = (object)adaptor.Create(NUMBER4);
				adaptor.AddChild(root_0, NUMBER4_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// MathLang.g:73:3: IDENT
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(73, 3);
				IDENT5=(IToken)Match(input,IDENT,Follow._IDENT_in_group586); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENT5_tree = (object)adaptor.Create(IDENT5);
				adaptor.AddChild(root_0, IDENT5_tree);
				}

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("group", 1);
			LeaveRule("group", 1);
			Leave_group();
			if (state.backtracking > 0) { Memoize(input, 1, group_StartIndex); }
		}
		DebugLocation(74, 0);
		} finally { DebugExitRule(GrammarFileName, "group"); }
		return retval;

	}
	// $ANTLR end "group"

	public class mult_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_mult();
	partial void Leave_mult();

	// $ANTLR start "mult"
	// MathLang.g:77:1: mult : group ( ( MUL | DIV ) group )* ;
	[GrammarRule("mult")]
	private MathLangParser.mult_return mult()
	{
		Enter_mult();
		EnterRule("mult", 2);
		TraceIn("mult", 2);
		MathLangParser.mult_return retval = new MathLangParser.mult_return();
		retval.Start = (IToken)input.LT(1);
		int mult_StartIndex = input.Index;
		object root_0 = null;

		IToken set7=null;
		MathLangParser.group_return group6 = default(MathLangParser.group_return);
		MathLangParser.group_return group8 = default(MathLangParser.group_return);

		object set7_tree=null;

		try { DebugEnterRule(GrammarFileName, "mult");
		DebugLocation(77, 39);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 2)) { return retval; }
			// MathLang.g:77:5: ( group ( ( MUL | DIV ) group )* )
			DebugEnterAlt(1);
			// MathLang.g:77:7: group ( ( MUL | DIV ) group )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(77, 7);
			PushFollow(Follow._group_in_mult595);
			group6=group();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, group6.Tree);
			DebugLocation(77, 13);
			// MathLang.g:77:13: ( ( MUL | DIV ) group )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if (((LA2_0>=MUL && LA2_0<=DIV)))
				{
					alt2=1;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:77:15: ( MUL | DIV ) group
					{
					DebugLocation(77, 15);
					set7=(IToken)input.LT(1);
					set7=(IToken)input.LT(1);
					if ((input.LA(1)>=MUL && input.LA(1)<=DIV))
					{
						input.Consume();
						if ( state.backtracking == 0 ) root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set7), root_0);
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(77, 30);
					PushFollow(Follow._group_in_mult610);
					group8=group();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, group8.Tree);

					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;

			} finally { DebugExitSubRule(2); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("mult", 2);
			LeaveRule("mult", 2);
			Leave_mult();
			if (state.backtracking > 0) { Memoize(input, 2, mult_StartIndex); }
		}
		DebugLocation(77, 39);
		} finally { DebugExitRule(GrammarFileName, "mult"); }
		return retval;

	}
	// $ANTLR end "mult"

	public class add_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_add();
	partial void Leave_add();

	// $ANTLR start "add"
	// MathLang.g:78:1: add : mult ( ( ADD | SUB ) mult )* ;
	[GrammarRule("add")]
	private MathLangParser.add_return add()
	{
		Enter_add();
		EnterRule("add", 3);
		TraceIn("add", 3);
		MathLangParser.add_return retval = new MathLangParser.add_return();
		retval.Start = (IToken)input.LT(1);
		int add_StartIndex = input.Index;
		object root_0 = null;

		IToken set10=null;
		MathLangParser.mult_return mult9 = default(MathLangParser.mult_return);
		MathLangParser.mult_return mult11 = default(MathLangParser.mult_return);

		object set10_tree=null;

		try { DebugEnterRule(GrammarFileName, "add");
		DebugLocation(78, 39);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 3)) { return retval; }
			// MathLang.g:78:4: ( mult ( ( ADD | SUB ) mult )* )
			DebugEnterAlt(1);
			// MathLang.g:78:7: mult ( ( ADD | SUB ) mult )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(78, 7);
			PushFollow(Follow._mult_in_add622);
			mult9=mult();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, mult9.Tree);
			DebugLocation(78, 13);
			// MathLang.g:78:13: ( ( ADD | SUB ) mult )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if (((LA3_0>=ADD && LA3_0<=SUB)))
				{
					alt3=1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:78:15: ( ADD | SUB ) mult
					{
					DebugLocation(78, 15);
					set10=(IToken)input.LT(1);
					set10=(IToken)input.LT(1);
					if ((input.LA(1)>=ADD && input.LA(1)<=SUB))
					{
						input.Consume();
						if ( state.backtracking == 0 ) root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set10), root_0);
						state.errorRecovery=false;state.failed=false;
					}
					else
					{
						if (state.backtracking>0) {state.failed=true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}

					DebugLocation(78, 30);
					PushFollow(Follow._mult_in_add638);
					mult11=mult();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, mult11.Tree);

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("add", 3);
			LeaveRule("add", 3);
			Leave_add();
			if (state.backtracking > 0) { Memoize(input, 3, add_StartIndex); }
		}
		DebugLocation(78, 39);
		} finally { DebugExitRule(GrammarFileName, "add"); }
		return retval;

	}
	// $ANTLR end "add"

	public class compare_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_compare();
	partial void Leave_compare();

	// $ANTLR start "compare"
	// MathLang.g:79:1: compare : add ( ( GE | LE | NEQUALS | EQUALS | GT | LT ) add )? ;
	[GrammarRule("compare")]
	private MathLangParser.compare_return compare()
	{
		Enter_compare();
		EnterRule("compare", 4);
		TraceIn("compare", 4);
		MathLangParser.compare_return retval = new MathLangParser.compare_return();
		retval.Start = (IToken)input.LT(1);
		int compare_StartIndex = input.Index;
		object root_0 = null;

		IToken set13=null;
		MathLangParser.add_return add12 = default(MathLangParser.add_return);
		MathLangParser.add_return add14 = default(MathLangParser.add_return);

		object set13_tree=null;

		try { DebugEnterRule(GrammarFileName, "compare");
		DebugLocation(79, 64);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 4)) { return retval; }
			// MathLang.g:79:8: ( add ( ( GE | LE | NEQUALS | EQUALS | GT | LT ) add )? )
			DebugEnterAlt(1);
			// MathLang.g:79:10: add ( ( GE | LE | NEQUALS | EQUALS | GT | LT ) add )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(79, 10);
			PushFollow(Follow._add_in_compare650);
			add12=add();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, add12.Tree);
			DebugLocation(79, 14);
			// MathLang.g:79:14: ( ( GE | LE | NEQUALS | EQUALS | GT | LT ) add )?
			int alt4=2;
			try { DebugEnterSubRule(4);
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if (((LA4_0>=GE && LA4_0<=LT)))
			{
				alt4=1;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:79:16: ( GE | LE | NEQUALS | EQUALS | GT | LT ) add
				{
				DebugLocation(79, 16);
				set13=(IToken)input.LT(1);
				set13=(IToken)input.LT(1);
				if ((input.LA(1)>=GE && input.LA(1)<=LT))
				{
					input.Consume();
					if ( state.backtracking == 0 ) root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set13), root_0);
					state.errorRecovery=false;state.failed=false;
				}
				else
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}

				DebugLocation(79, 57);
				PushFollow(Follow._add_in_compare680);
				add14=add();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, add14.Tree);

				}
				break;

			}
			} finally { DebugExitSubRule(4); }


			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("compare", 4);
			LeaveRule("compare", 4);
			Leave_compare();
			if (state.backtracking > 0) { Memoize(input, 4, compare_StartIndex); }
		}
		DebugLocation(79, 64);
		} finally { DebugExitRule(GrammarFileName, "compare"); }
		return retval;

	}
	// $ANTLR end "compare"

	public class term_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_term();
	partial void Leave_term();

	// $ANTLR start "term"
	// MathLang.g:80:1: term : compare ;
	[GrammarRule("term")]
	private MathLangParser.term_return term()
	{
		Enter_term();
		EnterRule("term", 5);
		TraceIn("term", 5);
		MathLangParser.term_return retval = new MathLangParser.term_return();
		retval.Start = (IToken)input.LT(1);
		int term_StartIndex = input.Index;
		object root_0 = null;

		MathLangParser.compare_return compare15 = default(MathLangParser.compare_return);


		try { DebugEnterRule(GrammarFileName, "term");
		DebugLocation(80, 15);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 5)) { return retval; }
			// MathLang.g:80:5: ( compare )
			DebugEnterAlt(1);
			// MathLang.g:80:7: compare
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(80, 7);
			PushFollow(Follow._compare_in_term691);
			compare15=compare();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compare15.Tree);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("term", 5);
			LeaveRule("term", 5);
			Leave_term();
			if (state.backtracking > 0) { Memoize(input, 5, term_StartIndex); }
		}
		DebugLocation(80, 15);
		} finally { DebugExitRule(GrammarFileName, "term"); }
		return retval;

	}
	// $ANTLR end "term"

	public class formal_params_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_formal_params();
	partial void Leave_formal_params();

	// $ANTLR start "formal_params"
	// MathLang.g:82:1: formal_params : ( IDENT ( ',' IDENT )* )? -> ^( PARAMS ( IDENT )* ) ;
	[GrammarRule("formal_params")]
	private MathLangParser.formal_params_return formal_params()
	{
		Enter_formal_params();
		EnterRule("formal_params", 6);
		TraceIn("formal_params", 6);
		MathLangParser.formal_params_return retval = new MathLangParser.formal_params_return();
		retval.Start = (IToken)input.LT(1);
		int formal_params_StartIndex = input.Index;
		object root_0 = null;

		IToken IDENT16=null;
		IToken char_literal17=null;
		IToken IDENT18=null;

		object IDENT16_tree=null;
		object char_literal17_tree=null;
		object IDENT18_tree=null;
		RewriteRuleITokenStream stream_33=new RewriteRuleITokenStream(adaptor,"token 33");
		RewriteRuleITokenStream stream_IDENT=new RewriteRuleITokenStream(adaptor,"token IDENT");

		try { DebugEnterRule(GrammarFileName, "formal_params");
		DebugLocation(82, 60);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 6)) { return retval; }
			// MathLang.g:82:14: ( ( IDENT ( ',' IDENT )* )? -> ^( PARAMS ( IDENT )* ) )
			DebugEnterAlt(1);
			// MathLang.g:82:16: ( IDENT ( ',' IDENT )* )?
			{
			DebugLocation(82, 16);
			// MathLang.g:82:16: ( IDENT ( ',' IDENT )* )?
			int alt6=2;
			try { DebugEnterSubRule(6);
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			int LA6_0 = input.LA(1);

			if ((LA6_0==IDENT))
			{
				alt6=1;
			}
			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:82:18: IDENT ( ',' IDENT )*
				{
				DebugLocation(82, 18);
				IDENT16=(IToken)Match(input,IDENT,Follow._IDENT_in_formal_params702); if (state.failed) return retval; 
				if ( state.backtracking == 0 ) stream_IDENT.Add(IDENT16);

				DebugLocation(82, 24);
				// MathLang.g:82:24: ( ',' IDENT )*
				try { DebugEnterSubRule(5);
				while (true)
				{
					int alt5=2;
					try { DebugEnterDecision(5, decisionCanBacktrack[5]);
					int LA5_0 = input.LA(1);

					if ((LA5_0==33))
					{
						alt5=1;
					}


					} finally { DebugExitDecision(5); }
					switch ( alt5 )
					{
					case 1:
						DebugEnterAlt(1);
						// MathLang.g:82:25: ',' IDENT
						{
						DebugLocation(82, 25);
						char_literal17=(IToken)Match(input,33,Follow._33_in_formal_params705); if (state.failed) return retval; 
						if ( state.backtracking == 0 ) stream_33.Add(char_literal17);

						DebugLocation(82, 29);
						IDENT18=(IToken)Match(input,IDENT,Follow._IDENT_in_formal_params707); if (state.failed) return retval; 
						if ( state.backtracking == 0 ) stream_IDENT.Add(IDENT18);


						}
						break;

					default:
						goto loop5;
					}
				}

				loop5:
					;

				} finally { DebugExitSubRule(5); }


				}
				break;

			}
			} finally { DebugExitSubRule(6); }



			{
			// AST REWRITE
			// elements: IDENT
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			if ( state.backtracking == 0 ) {
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 82:40: -> ^( PARAMS ( IDENT )* )
			{
				DebugLocation(82, 43);
				// MathLang.g:82:43: ^( PARAMS ( IDENT )* )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(82, 45);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMS, "PARAMS"), root_1);

				DebugLocation(82, 52);
				// MathLang.g:82:52: ( IDENT )*
				while ( stream_IDENT.HasNext )
				{
					DebugLocation(82, 52);
					adaptor.AddChild(root_1, stream_IDENT.NextNode());

				}
				stream_IDENT.Reset();

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("formal_params", 6);
			LeaveRule("formal_params", 6);
			Leave_formal_params();
			if (state.backtracking > 0) { Memoize(input, 6, formal_params_StartIndex); }
		}
		DebugLocation(82, 60);
		} finally { DebugExitRule(GrammarFileName, "formal_params"); }
		return retval;

	}
	// $ANTLR end "formal_params"

	public class func_decl_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_func_decl();
	partial void Leave_func_decl();

	// $ANTLR start "func_decl"
	// MathLang.g:83:1: func_decl : FUNCTION IDENT '(' formal_params ')' '{' exprList '}' ;
	[GrammarRule("func_decl")]
	private MathLangParser.func_decl_return func_decl()
	{
		Enter_func_decl();
		EnterRule("func_decl", 7);
		TraceIn("func_decl", 7);
		MathLangParser.func_decl_return retval = new MathLangParser.func_decl_return();
		retval.Start = (IToken)input.LT(1);
		int func_decl_StartIndex = input.Index;
		object root_0 = null;

		IToken FUNCTION19=null;
		IToken IDENT20=null;
		IToken char_literal21=null;
		IToken char_literal23=null;
		IToken char_literal24=null;
		IToken char_literal26=null;
		MathLangParser.formal_params_return formal_params22 = default(MathLangParser.formal_params_return);
		MathLangParser.exprList_return exprList25 = default(MathLangParser.exprList_return);

		object FUNCTION19_tree=null;
		object IDENT20_tree=null;
		object char_literal21_tree=null;
		object char_literal23_tree=null;
		object char_literal24_tree=null;
		object char_literal26_tree=null;

		try { DebugEnterRule(GrammarFileName, "func_decl");
		DebugLocation(83, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 7)) { return retval; }
			// MathLang.g:83:10: ( FUNCTION IDENT '(' formal_params ')' '{' exprList '}' )
			DebugEnterAlt(1);
			// MathLang.g:84:3: FUNCTION IDENT '(' formal_params ')' '{' exprList '}'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(84, 11);
			FUNCTION19=(IToken)Match(input,FUNCTION,Follow._FUNCTION_in_func_decl731); if (state.failed) return retval;
			if ( state.backtracking == 0 ) {
			FUNCTION19_tree = (object)adaptor.Create(FUNCTION19);
			root_0 = (object)adaptor.BecomeRoot(FUNCTION19_tree, root_0);
			}
			DebugLocation(84, 13);
			IDENT20=(IToken)Match(input,IDENT,Follow._IDENT_in_func_decl734); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			IDENT20_tree = (object)adaptor.Create(IDENT20);
			adaptor.AddChild(root_0, IDENT20_tree);
			}
			DebugLocation(84, 22);
			char_literal21=(IToken)Match(input,31,Follow._31_in_func_decl736); if (state.failed) return retval;
			DebugLocation(84, 24);
			PushFollow(Follow._formal_params_in_func_decl739);
			formal_params22=formal_params();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formal_params22.Tree);
			DebugLocation(84, 41);
			char_literal23=(IToken)Match(input,32,Follow._32_in_func_decl741); if (state.failed) return retval;
			DebugLocation(85, 6);
			char_literal24=(IToken)Match(input,34,Follow._34_in_func_decl746); if (state.failed) return retval;
			DebugLocation(85, 8);
			PushFollow(Follow._exprList_in_func_decl749);
			exprList25=exprList();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprList25.Tree);
			DebugLocation(85, 20);
			char_literal26=(IToken)Match(input,35,Follow._35_in_func_decl751); if (state.failed) return retval;

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("func_decl", 7);
			LeaveRule("func_decl", 7);
			Leave_func_decl();
			if (state.backtracking > 0) { Memoize(input, 7, func_decl_StartIndex); }
		}
		DebugLocation(86, 0);
		} finally { DebugExitRule(GrammarFileName, "func_decl"); }
		return retval;

	}
	// $ANTLR end "func_decl"

	public class expr1_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expr1();
	partial void Leave_expr1();

	// $ANTLR start "expr1"
	// MathLang.g:88:1: expr1 : ( PRINT term | INPUT IDENT | IDENT ASSIGN term | RETURN ( term )? );
	[GrammarRule("expr1")]
	private MathLangParser.expr1_return expr1()
	{
		Enter_expr1();
		EnterRule("expr1", 8);
		TraceIn("expr1", 8);
		MathLangParser.expr1_return retval = new MathLangParser.expr1_return();
		retval.Start = (IToken)input.LT(1);
		int expr1_StartIndex = input.Index;
		object root_0 = null;

		IToken PRINT27=null;
		IToken INPUT29=null;
		IToken IDENT30=null;
		IToken IDENT31=null;
		IToken ASSIGN32=null;
		IToken RETURN34=null;
		MathLangParser.term_return term28 = default(MathLangParser.term_return);
		MathLangParser.term_return term33 = default(MathLangParser.term_return);
		MathLangParser.term_return term35 = default(MathLangParser.term_return);

		object PRINT27_tree=null;
		object INPUT29_tree=null;
		object IDENT30_tree=null;
		object IDENT31_tree=null;
		object ASSIGN32_tree=null;
		object RETURN34_tree=null;

		try { DebugEnterRule(GrammarFileName, "expr1");
		DebugLocation(88, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 8)) { return retval; }
			// MathLang.g:88:6: ( PRINT term | INPUT IDENT | IDENT ASSIGN term | RETURN ( term )? )
			int alt8=4;
			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			switch (input.LA(1))
			{
			case PRINT:
				{
				alt8=1;
				}
				break;
			case INPUT:
				{
				alt8=2;
				}
				break;
			case IDENT:
				{
				alt8=3;
				}
				break;
			case RETURN:
				{
				alt8=4;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 8, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:89:3: PRINT term
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(89, 8);
				PRINT27=(IToken)Match(input,PRINT,Follow._PRINT_in_expr1762); if (state.failed) return retval;
				if ( state.backtracking == 0 ) {
				PRINT27_tree = (object)adaptor.Create(PRINT27);
				root_0 = (object)adaptor.BecomeRoot(PRINT27_tree, root_0);
				}
				DebugLocation(89, 10);
				PushFollow(Follow._term_in_expr1765);
				term28=term();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term28.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// MathLang.g:90:3: INPUT IDENT
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(90, 8);
				INPUT29=(IToken)Match(input,INPUT,Follow._INPUT_in_expr1769); if (state.failed) return retval;
				if ( state.backtracking == 0 ) {
				INPUT29_tree = (object)adaptor.Create(INPUT29);
				root_0 = (object)adaptor.BecomeRoot(INPUT29_tree, root_0);
				}
				DebugLocation(90, 10);
				IDENT30=(IToken)Match(input,IDENT,Follow._IDENT_in_expr1772); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENT30_tree = (object)adaptor.Create(IDENT30);
				adaptor.AddChild(root_0, IDENT30_tree);
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// MathLang.g:91:3: IDENT ASSIGN term
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(91, 3);
				IDENT31=(IToken)Match(input,IDENT,Follow._IDENT_in_expr1776); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				IDENT31_tree = (object)adaptor.Create(IDENT31);
				adaptor.AddChild(root_0, IDENT31_tree);
				}
				DebugLocation(91, 15);
				ASSIGN32=(IToken)Match(input,ASSIGN,Follow._ASSIGN_in_expr1778); if (state.failed) return retval;
				if ( state.backtracking == 0 ) {
				ASSIGN32_tree = (object)adaptor.Create(ASSIGN32);
				root_0 = (object)adaptor.BecomeRoot(ASSIGN32_tree, root_0);
				}
				DebugLocation(91, 17);
				PushFollow(Follow._term_in_expr1781);
				term33=term();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term33.Tree);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// MathLang.g:92:3: RETURN ( term )?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(92, 3);
				RETURN34=(IToken)Match(input,RETURN,Follow._RETURN_in_expr1785); if (state.failed) return retval;
				if ( state.backtracking==0 ) {
				RETURN34_tree = (object)adaptor.Create(RETURN34);
				adaptor.AddChild(root_0, RETURN34_tree);
				}
				DebugLocation(92, 10);
				// MathLang.g:92:10: ( term )?
				int alt7=2;
				try { DebugEnterSubRule(7);
				try { DebugEnterDecision(7, decisionCanBacktrack[7]);
				int LA7_0 = input.LA(1);

				if (((LA7_0>=NUMBER && LA7_0<=IDENT)||LA7_0==31))
				{
					alt7=1;
				}
				} finally { DebugExitDecision(7); }
				switch (alt7)
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:0:0: term
					{
					DebugLocation(92, 10);
					PushFollow(Follow._term_in_expr1787);
					term35=term();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term35.Tree);

					}
					break;

				}
				} finally { DebugExitSubRule(7); }


				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expr1", 8);
			LeaveRule("expr1", 8);
			Leave_expr1();
			if (state.backtracking > 0) { Memoize(input, 8, expr1_StartIndex); }
		}
		DebugLocation(93, 0);
		} finally { DebugExitRule(GrammarFileName, "expr1"); }
		return retval;

	}
	// $ANTLR end "expr1"

	public class expr2_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expr2();
	partial void Leave_expr2();

	// $ANTLR start "expr2"
	// MathLang.g:95:1: expr2 : ( '{' exprList '}' | WHILE '(' term ')' expr | IF '(' term ')' expr ( 'else' expr )? | FOR '(' expr1 ';' term ';' expr1 ')' expr | func_decl );
	[GrammarRule("expr2")]
	private MathLangParser.expr2_return expr2()
	{
		Enter_expr2();
		EnterRule("expr2", 9);
		TraceIn("expr2", 9);
		MathLangParser.expr2_return retval = new MathLangParser.expr2_return();
		retval.Start = (IToken)input.LT(1);
		int expr2_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal36=null;
		IToken char_literal38=null;
		IToken WHILE39=null;
		IToken char_literal40=null;
		IToken char_literal42=null;
		IToken IF44=null;
		IToken char_literal45=null;
		IToken char_literal47=null;
		IToken string_literal49=null;
		IToken FOR51=null;
		IToken char_literal52=null;
		IToken char_literal54=null;
		IToken char_literal56=null;
		IToken char_literal58=null;
		MathLangParser.exprList_return exprList37 = default(MathLangParser.exprList_return);
		MathLangParser.term_return term41 = default(MathLangParser.term_return);
		MathLangParser.expr_return expr43 = default(MathLangParser.expr_return);
		MathLangParser.term_return term46 = default(MathLangParser.term_return);
		MathLangParser.expr_return expr48 = default(MathLangParser.expr_return);
		MathLangParser.expr_return expr50 = default(MathLangParser.expr_return);
		MathLangParser.expr1_return expr153 = default(MathLangParser.expr1_return);
		MathLangParser.term_return term55 = default(MathLangParser.term_return);
		MathLangParser.expr1_return expr157 = default(MathLangParser.expr1_return);
		MathLangParser.expr_return expr59 = default(MathLangParser.expr_return);
		MathLangParser.func_decl_return func_decl60 = default(MathLangParser.func_decl_return);

		object char_literal36_tree=null;
		object char_literal38_tree=null;
		object WHILE39_tree=null;
		object char_literal40_tree=null;
		object char_literal42_tree=null;
		object IF44_tree=null;
		object char_literal45_tree=null;
		object char_literal47_tree=null;
		object string_literal49_tree=null;
		object FOR51_tree=null;
		object char_literal52_tree=null;
		object char_literal54_tree=null;
		object char_literal56_tree=null;
		object char_literal58_tree=null;

		try { DebugEnterRule(GrammarFileName, "expr2");
		DebugLocation(95, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 9)) { return retval; }
			// MathLang.g:95:6: ( '{' exprList '}' | WHILE '(' term ')' expr | IF '(' term ')' expr ( 'else' expr )? | FOR '(' expr1 ';' term ';' expr1 ')' expr | func_decl )
			int alt10=5;
			try { DebugEnterDecision(10, decisionCanBacktrack[10]);
			switch (input.LA(1))
			{
			case 34:
				{
				alt10=1;
				}
				break;
			case WHILE:
				{
				alt10=2;
				}
				break;
			case IF:
				{
				alt10=3;
				}
				break;
			case FOR:
				{
				alt10=4;
				}
				break;
			case FUNCTION:
				{
				alt10=5;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 10, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(10); }
			switch (alt10)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:96:3: '{' exprList '}'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(96, 6);
				char_literal36=(IToken)Match(input,34,Follow._34_in_expr2798); if (state.failed) return retval;
				DebugLocation(96, 8);
				PushFollow(Follow._exprList_in_expr2801);
				exprList37=exprList();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprList37.Tree);
				DebugLocation(96, 20);
				char_literal38=(IToken)Match(input,35,Follow._35_in_expr2803); if (state.failed) return retval;

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// MathLang.g:97:3: WHILE '(' term ')' expr
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(97, 8);
				WHILE39=(IToken)Match(input,WHILE,Follow._WHILE_in_expr2808); if (state.failed) return retval;
				if ( state.backtracking == 0 ) {
				WHILE39_tree = (object)adaptor.Create(WHILE39);
				root_0 = (object)adaptor.BecomeRoot(WHILE39_tree, root_0);
				}
				DebugLocation(97, 13);
				char_literal40=(IToken)Match(input,31,Follow._31_in_expr2811); if (state.failed) return retval;
				DebugLocation(97, 15);
				PushFollow(Follow._term_in_expr2814);
				term41=term();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term41.Tree);
				DebugLocation(97, 23);
				char_literal42=(IToken)Match(input,32,Follow._32_in_expr2816); if (state.failed) return retval;
				DebugLocation(97, 25);
				PushFollow(Follow._expr_in_expr2819);
				expr43=expr();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr43.Tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// MathLang.g:98:3: IF '(' term ')' expr ( 'else' expr )?
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(98, 5);
				IF44=(IToken)Match(input,IF,Follow._IF_in_expr2823); if (state.failed) return retval;
				if ( state.backtracking == 0 ) {
				IF44_tree = (object)adaptor.Create(IF44);
				root_0 = (object)adaptor.BecomeRoot(IF44_tree, root_0);
				}
				DebugLocation(98, 10);
				char_literal45=(IToken)Match(input,31,Follow._31_in_expr2826); if (state.failed) return retval;
				DebugLocation(98, 12);
				PushFollow(Follow._term_in_expr2829);
				term46=term();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term46.Tree);
				DebugLocation(98, 20);
				char_literal47=(IToken)Match(input,32,Follow._32_in_expr2831); if (state.failed) return retval;
				DebugLocation(98, 22);
				PushFollow(Follow._expr_in_expr2834);
				expr48=expr();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr48.Tree);
				DebugLocation(98, 27);
				// MathLang.g:98:27: ( 'else' expr )?
				int alt9=2;
				try { DebugEnterSubRule(9);
				try { DebugEnterDecision(9, decisionCanBacktrack[9]);
				int LA9_0 = input.LA(1);

				if ((LA9_0==36))
				{
					int LA9_1 = input.LA(2);

					if ((EvaluatePredicate(synpred21_MathLang_fragment)))
					{
						alt9=1;
					}
				}
				} finally { DebugExitDecision(9); }
				switch (alt9)
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:98:29: 'else' expr
					{
					DebugLocation(98, 35);
					string_literal49=(IToken)Match(input,36,Follow._36_in_expr2838); if (state.failed) return retval;
					DebugLocation(98, 37);
					PushFollow(Follow._expr_in_expr2841);
					expr50=expr();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr50.Tree);

					}
					break;

				}
				} finally { DebugExitSubRule(9); }


				}
				break;
			case 4:
				DebugEnterAlt(4);
				// MathLang.g:99:3: FOR '(' expr1 ';' term ';' expr1 ')' expr
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(99, 6);
				FOR51=(IToken)Match(input,FOR,Follow._FOR_in_expr2848); if (state.failed) return retval;
				if ( state.backtracking == 0 ) {
				FOR51_tree = (object)adaptor.Create(FOR51);
				root_0 = (object)adaptor.BecomeRoot(FOR51_tree, root_0);
				}
				DebugLocation(99, 11);
				char_literal52=(IToken)Match(input,31,Follow._31_in_expr2851); if (state.failed) return retval;
				DebugLocation(99, 13);
				PushFollow(Follow._expr1_in_expr2854);
				expr153=expr1();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr153.Tree);
				DebugLocation(99, 22);
				char_literal54=(IToken)Match(input,37,Follow._37_in_expr2856); if (state.failed) return retval;
				DebugLocation(99, 24);
				PushFollow(Follow._term_in_expr2859);
				term55=term();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, term55.Tree);
				DebugLocation(99, 32);
				char_literal56=(IToken)Match(input,37,Follow._37_in_expr2861); if (state.failed) return retval;
				DebugLocation(99, 34);
				PushFollow(Follow._expr1_in_expr2864);
				expr157=expr1();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr157.Tree);
				DebugLocation(99, 43);
				char_literal58=(IToken)Match(input,32,Follow._32_in_expr2866); if (state.failed) return retval;
				DebugLocation(99, 45);
				PushFollow(Follow._expr_in_expr2869);
				expr59=expr();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr59.Tree);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// MathLang.g:100:3: func_decl
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(100, 3);
				PushFollow(Follow._func_decl_in_expr2873);
				func_decl60=func_decl();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, func_decl60.Tree);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expr2", 9);
			LeaveRule("expr2", 9);
			Leave_expr2();
			if (state.backtracking > 0) { Memoize(input, 9, expr2_StartIndex); }
		}
		DebugLocation(101, 0);
		} finally { DebugExitRule(GrammarFileName, "expr2"); }
		return retval;

	}
	// $ANTLR end "expr2"

	public class expr_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expr();
	partial void Leave_expr();

	// $ANTLR start "expr"
	// MathLang.g:103:1: expr : ( expr1 ';' | expr2 );
	[GrammarRule("expr")]
	private MathLangParser.expr_return expr()
	{
		Enter_expr();
		EnterRule("expr", 10);
		TraceIn("expr", 10);
		MathLangParser.expr_return retval = new MathLangParser.expr_return();
		retval.Start = (IToken)input.LT(1);
		int expr_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal62=null;
		MathLangParser.expr1_return expr161 = default(MathLangParser.expr1_return);
		MathLangParser.expr2_return expr263 = default(MathLangParser.expr2_return);

		object char_literal62_tree=null;

		try { DebugEnterRule(GrammarFileName, "expr");
		DebugLocation(103, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 10)) { return retval; }
			// MathLang.g:103:5: ( expr1 ';' | expr2 )
			int alt11=2;
			try { DebugEnterDecision(11, decisionCanBacktrack[11]);
			int LA11_0 = input.LA(1);

			if (((LA11_0>=PRINT && LA11_0<=INPUT)||LA11_0==RETURN||LA11_0==IDENT))
			{
				alt11=1;
			}
			else if (((LA11_0>=IF && LA11_0<=FUNCTION)||LA11_0==WHILE||LA11_0==34))
			{
				alt11=2;
			}
			else
			{
				if (state.backtracking>0) {state.failed=true; return retval;}
				NoViableAltException nvae = new NoViableAltException("", 11, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(11); }
			switch (alt11)
			{
			case 1:
				DebugEnterAlt(1);
				// MathLang.g:104:3: expr1 ';'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(104, 3);
				PushFollow(Follow._expr1_in_expr883);
				expr161=expr1();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr161.Tree);
				DebugLocation(104, 12);
				char_literal62=(IToken)Match(input,37,Follow._37_in_expr885); if (state.failed) return retval;

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// MathLang.g:105:3: expr2
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(105, 3);
				PushFollow(Follow._expr2_in_expr890);
				expr263=expr2();
				PopFollow();
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expr263.Tree);

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expr", 10);
			LeaveRule("expr", 10);
			Leave_expr();
			if (state.backtracking > 0) { Memoize(input, 10, expr_StartIndex); }
		}
		DebugLocation(106, 0);
		} finally { DebugExitRule(GrammarFileName, "expr"); }
		return retval;

	}
	// $ANTLR end "expr"

	public class exprList_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_exprList();
	partial void Leave_exprList();

	// $ANTLR start "exprList"
	// MathLang.g:108:1: exprList : ( expr ( ';' )* )* -> ^( BLOCK ( expr )* ) ;
	[GrammarRule("exprList")]
	private MathLangParser.exprList_return exprList()
	{
		Enter_exprList();
		EnterRule("exprList", 11);
		TraceIn("exprList", 11);
		MathLangParser.exprList_return retval = new MathLangParser.exprList_return();
		retval.Start = (IToken)input.LT(1);
		int exprList_StartIndex = input.Index;
		object root_0 = null;

		IToken char_literal65=null;
		MathLangParser.expr_return expr64 = default(MathLangParser.expr_return);

		object char_literal65_tree=null;
		RewriteRuleITokenStream stream_37=new RewriteRuleITokenStream(adaptor,"token 37");
		RewriteRuleSubtreeStream stream_expr=new RewriteRuleSubtreeStream(adaptor,"rule expr");
		try { DebugEnterRule(GrammarFileName, "exprList");
		DebugLocation(108, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 11)) { return retval; }
			// MathLang.g:108:9: ( ( expr ( ';' )* )* -> ^( BLOCK ( expr )* ) )
			DebugEnterAlt(1);
			// MathLang.g:109:3: ( expr ( ';' )* )*
			{
			DebugLocation(109, 3);
			// MathLang.g:109:3: ( expr ( ';' )* )*
			try { DebugEnterSubRule(13);
			while (true)
			{
				int alt13=2;
				try { DebugEnterDecision(13, decisionCanBacktrack[13]);
				int LA13_0 = input.LA(1);

				if (((LA13_0>=PRINT && LA13_0<=WHILE)||LA13_0==IDENT||LA13_0==34))
				{
					alt13=1;
				}


				} finally { DebugExitDecision(13); }
				switch ( alt13 )
				{
				case 1:
					DebugEnterAlt(1);
					// MathLang.g:109:5: expr ( ';' )*
					{
					DebugLocation(109, 5);
					PushFollow(Follow._expr_in_exprList902);
					expr64=expr();
					PopFollow();
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) stream_expr.Add(expr64.Tree);
					DebugLocation(109, 10);
					// MathLang.g:109:10: ( ';' )*
					try { DebugEnterSubRule(12);
					while (true)
					{
						int alt12=2;
						try { DebugEnterDecision(12, decisionCanBacktrack[12]);
						int LA12_0 = input.LA(1);

						if ((LA12_0==37))
						{
							alt12=1;
						}


						} finally { DebugExitDecision(12); }
						switch ( alt12 )
						{
						case 1:
							DebugEnterAlt(1);
							// MathLang.g:0:0: ';'
							{
							DebugLocation(109, 10);
							char_literal65=(IToken)Match(input,37,Follow._37_in_exprList904); if (state.failed) return retval; 
							if ( state.backtracking == 0 ) stream_37.Add(char_literal65);


							}
							break;

						default:
							goto loop12;
						}
					}

					loop12:
						;

					} finally { DebugExitSubRule(12); }


					}
					break;

				default:
					goto loop13;
				}
			}

			loop13:
				;

			} finally { DebugExitSubRule(13); }



			{
			// AST REWRITE
			// elements: expr
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			if ( state.backtracking == 0 ) {
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 109:18: -> ^( BLOCK ( expr )* )
			{
				DebugLocation(109, 21);
				// MathLang.g:109:21: ^( BLOCK ( expr )* )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(109, 23);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(BLOCK, "BLOCK"), root_1);

				DebugLocation(109, 29);
				// MathLang.g:109:29: ( expr )*
				while ( stream_expr.HasNext )
				{
					DebugLocation(109, 29);
					adaptor.AddChild(root_1, stream_expr.NextTree());

				}
				stream_expr.Reset();

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("exprList", 11);
			LeaveRule("exprList", 11);
			Leave_exprList();
			if (state.backtracking > 0) { Memoize(input, 11, exprList_StartIndex); }
		}
		DebugLocation(110, 0);
		} finally { DebugExitRule(GrammarFileName, "exprList"); }
		return retval;

	}
	// $ANTLR end "exprList"

	public class program_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_program();
	partial void Leave_program();

	// $ANTLR start "program"
	// MathLang.g:112:1: program : exprList ;
	[GrammarRule("program")]
	private MathLangParser.program_return program()
	{
		Enter_program();
		EnterRule("program", 12);
		TraceIn("program", 12);
		MathLangParser.program_return retval = new MathLangParser.program_return();
		retval.Start = (IToken)input.LT(1);
		int program_StartIndex = input.Index;
		object root_0 = null;

		MathLangParser.exprList_return exprList66 = default(MathLangParser.exprList_return);


		try { DebugEnterRule(GrammarFileName, "program");
		DebugLocation(112, 19);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 12)) { return retval; }
			// MathLang.g:112:8: ( exprList )
			DebugEnterAlt(1);
			// MathLang.g:112:10: exprList
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(112, 10);
			PushFollow(Follow._exprList_in_program925);
			exprList66=exprList();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exprList66.Tree);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("program", 12);
			LeaveRule("program", 12);
			Leave_program();
			if (state.backtracking > 0) { Memoize(input, 12, program_StartIndex); }
		}
		DebugLocation(112, 19);
		} finally { DebugExitRule(GrammarFileName, "program"); }
		return retval;

	}
	// $ANTLR end "program"

	public class result_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_result();
	partial void Leave_result();

	// $ANTLR start "result"
	// MathLang.g:114:1: result : program EOF ;
	[GrammarRule("result")]
	private MathLangParser.result_return result()
	{
		Enter_result();
		EnterRule("result", 13);
		TraceIn("result", 13);
		MathLangParser.result_return retval = new MathLangParser.result_return();
		retval.Start = (IToken)input.LT(1);
		int result_StartIndex = input.Index;
		object root_0 = null;

		IToken EOF68=null;
		MathLangParser.program_return program67 = default(MathLangParser.program_return);

		object EOF68_tree=null;

		try { DebugEnterRule(GrammarFileName, "result");
		DebugLocation(114, 20);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 13)) { return retval; }
			// MathLang.g:114:7: ( program EOF )
			DebugEnterAlt(1);
			// MathLang.g:114:9: program EOF
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(114, 9);
			PushFollow(Follow._program_in_result934);
			program67=program();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, program67.Tree);
			DebugLocation(114, 20);
			EOF68=(IToken)Match(input,EOF,Follow._EOF_in_result936); if (state.failed) return retval;

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("result", 13);
			LeaveRule("result", 13);
			Leave_result();
			if (state.backtracking > 0) { Memoize(input, 13, result_StartIndex); }
		}
		DebugLocation(114, 20);
		} finally { DebugExitRule(GrammarFileName, "result"); }
		return retval;

	}
	// $ANTLR end "result"

	public class execute_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_execute();
	partial void Leave_execute();

	// $ANTLR start "execute"
	// MathLang.g:116:8: public execute : result ;
	[GrammarRule("execute")]
	public MathLangParser.execute_return execute()
	{
		Enter_execute();
		EnterRule("execute", 14);
		TraceIn("execute", 14);
		MathLangParser.execute_return retval = new MathLangParser.execute_return();
		retval.Start = (IToken)input.LT(1);
		int execute_StartIndex = input.Index;
		object root_0 = null;

		MathLangParser.result_return result69 = default(MathLangParser.result_return);


		try { DebugEnterRule(GrammarFileName, "execute");
		DebugLocation(116, 0);
		try
		{
			if (state.backtracking > 0 && AlreadyParsedRule(input, 14)) { return retval; }
			// MathLang.g:116:15: ( result )
			DebugEnterAlt(1);
			// MathLang.g:117:3: result
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(117, 3);
			PushFollow(Follow._result_in_execute948);
			result69=result();
			PopFollow();
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, result69.Tree);

			}

			retval.Stop = (IToken)input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);
			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("execute", 14);
			LeaveRule("execute", 14);
			Leave_execute();
			if (state.backtracking > 0) { Memoize(input, 14, execute_StartIndex); }
		}
		DebugLocation(118, 0);
		} finally { DebugExitRule(GrammarFileName, "execute"); }
		return retval;

	}
	// $ANTLR end "execute"

	partial void Enter_synpred21_MathLang_fragment();
	partial void Leave_synpred21_MathLang_fragment();

	// $ANTLR start synpred21_MathLang
	public void synpred21_MathLang_fragment()
	{
		Enter_synpred21_MathLang_fragment();
		EnterRule("synpred21_MathLang_fragment", 35);
		TraceIn("synpred21_MathLang_fragment", 35);
		try
		{
			// MathLang.g:98:29: ( 'else' expr )
			DebugEnterAlt(1);
			// MathLang.g:98:29: 'else' expr
			{
			DebugLocation(98, 29);
			Match(input,36,Follow._36_in_synpred21_MathLang838); if (state.failed) return;
			DebugLocation(98, 37);
			PushFollow(Follow._expr_in_synpred21_MathLang841);
			expr();
			PopFollow();
			if (state.failed) return;

			}

		}
		finally
		{
			TraceOut("synpred21_MathLang_fragment", 35);
			LeaveRule("synpred21_MathLang_fragment", 35);
			Leave_synpred21_MathLang_fragment();
		}
	}
	// $ANTLR end synpred21_MathLang
	#endregion Rules

	#region Synpreds
	private bool EvaluatePredicate(System.Action fragment)
	{
		bool success = false;
		state.backtracking++;
		try { DebugBeginBacktrack(state.backtracking);
		int start = input.Mark();
		try
		{
			fragment();
		}
		catch ( RecognitionException re )
		{
			System.Console.Error.WriteLine("impossible: "+re);
		}
		success = !state.failed;
		input.Rewind(start);
		} finally { DebugEndBacktrack(state.backtracking, success); }
		state.backtracking--;
		state.failed=false;
		return success;
	}
	#endregion Synpreds


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _31_in_group572 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _term_in_group575 = new BitSet(new ulong[]{0x100000000UL});
		public static readonly BitSet _32_in_group577 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NUMBER_in_group582 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENT_in_group586 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _group_in_mult595 = new BitSet(new ulong[]{0xC00002UL});
		public static readonly BitSet _set_in_mult599 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _group_in_mult610 = new BitSet(new ulong[]{0xC00002UL});
		public static readonly BitSet _mult_in_add622 = new BitSet(new ulong[]{0x300002UL});
		public static readonly BitSet _set_in_add627 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _mult_in_add638 = new BitSet(new ulong[]{0x300002UL});
		public static readonly BitSet _add_in_compare650 = new BitSet(new ulong[]{0x3F000002UL});
		public static readonly BitSet _set_in_compare654 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _add_in_compare680 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _compare_in_term691 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENT_in_formal_params702 = new BitSet(new ulong[]{0x200000002UL});
		public static readonly BitSet _33_in_formal_params705 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _IDENT_in_formal_params707 = new BitSet(new ulong[]{0x200000002UL});
		public static readonly BitSet _FUNCTION_in_func_decl731 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _IDENT_in_func_decl734 = new BitSet(new ulong[]{0x80000000UL});
		public static readonly BitSet _31_in_func_decl736 = new BitSet(new ulong[]{0x100080000UL});
		public static readonly BitSet _formal_params_in_func_decl739 = new BitSet(new ulong[]{0x100000000UL});
		public static readonly BitSet _32_in_func_decl741 = new BitSet(new ulong[]{0x400000000UL});
		public static readonly BitSet _34_in_func_decl746 = new BitSet(new ulong[]{0xC00080FE0UL});
		public static readonly BitSet _exprList_in_func_decl749 = new BitSet(new ulong[]{0x800000000UL});
		public static readonly BitSet _35_in_func_decl751 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _PRINT_in_expr1762 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _term_in_expr1765 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _INPUT_in_expr1769 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _IDENT_in_expr1772 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENT_in_expr1776 = new BitSet(new ulong[]{0x40000000UL});
		public static readonly BitSet _ASSIGN_in_expr1778 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _term_in_expr1781 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _RETURN_in_expr1785 = new BitSet(new ulong[]{0x800C0002UL});
		public static readonly BitSet _term_in_expr1787 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _34_in_expr2798 = new BitSet(new ulong[]{0xC00080FE0UL});
		public static readonly BitSet _exprList_in_expr2801 = new BitSet(new ulong[]{0x800000000UL});
		public static readonly BitSet _35_in_expr2803 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WHILE_in_expr2808 = new BitSet(new ulong[]{0x80000000UL});
		public static readonly BitSet _31_in_expr2811 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _term_in_expr2814 = new BitSet(new ulong[]{0x100000000UL});
		public static readonly BitSet _32_in_expr2816 = new BitSet(new ulong[]{0x400080FE0UL});
		public static readonly BitSet _expr_in_expr2819 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IF_in_expr2823 = new BitSet(new ulong[]{0x80000000UL});
		public static readonly BitSet _31_in_expr2826 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _term_in_expr2829 = new BitSet(new ulong[]{0x100000000UL});
		public static readonly BitSet _32_in_expr2831 = new BitSet(new ulong[]{0x400080FE0UL});
		public static readonly BitSet _expr_in_expr2834 = new BitSet(new ulong[]{0x1000000002UL});
		public static readonly BitSet _36_in_expr2838 = new BitSet(new ulong[]{0x400080FE0UL});
		public static readonly BitSet _expr_in_expr2841 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _FOR_in_expr2848 = new BitSet(new ulong[]{0x80000000UL});
		public static readonly BitSet _31_in_expr2851 = new BitSet(new ulong[]{0x80460UL});
		public static readonly BitSet _expr1_in_expr2854 = new BitSet(new ulong[]{0x2000000000UL});
		public static readonly BitSet _37_in_expr2856 = new BitSet(new ulong[]{0x800C0000UL});
		public static readonly BitSet _term_in_expr2859 = new BitSet(new ulong[]{0x2000000000UL});
		public static readonly BitSet _37_in_expr2861 = new BitSet(new ulong[]{0x80460UL});
		public static readonly BitSet _expr1_in_expr2864 = new BitSet(new ulong[]{0x100000000UL});
		public static readonly BitSet _32_in_expr2866 = new BitSet(new ulong[]{0x400080FE0UL});
		public static readonly BitSet _expr_in_expr2869 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _func_decl_in_expr2873 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expr1_in_expr883 = new BitSet(new ulong[]{0x2000000000UL});
		public static readonly BitSet _37_in_expr885 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expr2_in_expr890 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expr_in_exprList902 = new BitSet(new ulong[]{0x2400080FE2UL});
		public static readonly BitSet _37_in_exprList904 = new BitSet(new ulong[]{0x2400080FE2UL});
		public static readonly BitSet _exprList_in_program925 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _program_in_result934 = new BitSet(new ulong[]{0x0UL});
		public static readonly BitSet _EOF_in_result936 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _result_in_execute948 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _36_in_synpred21_MathLang838 = new BitSet(new ulong[]{0x400080FE0UL});
		public static readonly BitSet _expr_in_synpred21_MathLang841 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}

} // namespace  MathLang 
