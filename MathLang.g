grammar MathLang;

options {
  language=CSharp3;
  output=AST;

  backtrack=true;
  memoize=true;
}


tokens {
  UNKNOWN             ;
  PRINT   = 'print'   ;
  INPUT   = 'input'   ;
  IF = 'if'           ;
  FOR = 'for'         ;
  FUNCTION = 'function' ;
  RETURN = 'return'   ;
  WHILE = 'while'     ;
  BLOCK               ;
  PROGRAM             ;
  PARAMS              ;
}


@lexer::namespace { MathLang }
@parser::namespace { MathLang }


WS:
  ( ' ' | '\t' |  '\f' | '\r' | '\n' )+ {
    $channel=Hidden;
  }
;

SL_COMMENT:
  '//' (options { greedy=false; }: .)* '\r'? '\n' {
    $channel=Hidden;
  }
;
ML_COMMENT:
  '/*' (options { greedy=false; }: .)* '*/' {
    $channel=Hidden;
  }
;



NUMBER: ('0'..'9')+ ('.' ('0'..'9')+)?
;
IDENT:  ( 'a'..'z' | 'A'..'Z' | '_' )
        ( 'a'..'z' | 'A'..'Z' | '_' | '0'..'9' )*
;
ADD:    '+'     ;
SUB:    '-'     ;
MUL:    '*'     ;
DIV:    '/'     ;

GE:       '>='  ;
LE:       '<='  ;
NEQUALS:  '<>'  ;
EQUALS:   '=='  ;
GT:       '>'   ;
LT:       '<'   ;

ASSIGN: '='     ;


group:
  '('! term ')'!
| NUMBER
| IDENT
;


mult: group ( ( MUL | DIV )^ group )*  ;
add:  mult  ( ( ADD | SUB )^ mult  )*  ;
compare: add ( ( GE | LE | NEQUALS | EQUALS | GT | LT)^ add )?  ;
term: compare  ;

formal_params: ( IDENT (',' IDENT)* )? -> ^(PARAMS IDENT*)  ;
func_decl:
  FUNCTION^ IDENT '('! formal_params ')'!
  '{'! exprList '}'!
;

expr1:
  PRINT^ term
| INPUT^ IDENT
| IDENT ASSIGN^ term
| RETURN term?
;

expr2:
  '{'! exprList '}'!
| WHILE^ '('! term ')'! expr
| IF^ '('! term ')'! expr ( 'else'! expr )?
| FOR^ '('! expr1 ';'! term ';'! expr1 ')'! expr
| func_decl
;

expr:
  expr1 ';'!
| expr2
;

exprList:
  ( expr ';'* )* -> ^(BLOCK expr*)
;

program: exprList  ;

result: program EOF!;

public execute:
  result
;
