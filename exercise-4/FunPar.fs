// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | COMMA
  | LPAR
  | RPAR
  | LBRACK
  | RBRACK
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | AT
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_COMMA
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_LBRACK
    | TOKEN_RBRACK
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_AT
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const
    | NONTERM_List

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | COMMA  -> 1 
  | LPAR  -> 2 
  | RPAR  -> 3 
  | LBRACK  -> 4 
  | RBRACK  -> 5 
  | EQ  -> 6 
  | NE  -> 7 
  | GT  -> 8 
  | LT  -> 9 
  | GE  -> 10 
  | LE  -> 11 
  | PLUS  -> 12 
  | MINUS  -> 13 
  | TIMES  -> 14 
  | DIV  -> 15 
  | MOD  -> 16 
  | AT  -> 17 
  | ELSE  -> 18 
  | END  -> 19 
  | FALSE  -> 20 
  | IF  -> 21 
  | IN  -> 22 
  | LET  -> 23 
  | NOT  -> 24 
  | THEN  -> 25 
  | TRUE  -> 26 
  | CSTBOOL _ -> 27 
  | NAME _ -> 28 
  | CSTINT _ -> 29 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_COMMA 
  | 2 -> TOKEN_LPAR 
  | 3 -> TOKEN_RPAR 
  | 4 -> TOKEN_LBRACK 
  | 5 -> TOKEN_RBRACK 
  | 6 -> TOKEN_EQ 
  | 7 -> TOKEN_NE 
  | 8 -> TOKEN_GT 
  | 9 -> TOKEN_LT 
  | 10 -> TOKEN_GE 
  | 11 -> TOKEN_LE 
  | 12 -> TOKEN_PLUS 
  | 13 -> TOKEN_MINUS 
  | 14 -> TOKEN_TIMES 
  | 15 -> TOKEN_DIV 
  | 16 -> TOKEN_MOD 
  | 17 -> TOKEN_AT 
  | 18 -> TOKEN_ELSE 
  | 19 -> TOKEN_END 
  | 20 -> TOKEN_FALSE 
  | 21 -> TOKEN_IF 
  | 22 -> TOKEN_IN 
  | 23 -> TOKEN_LET 
  | 24 -> TOKEN_NOT 
  | 25 -> TOKEN_THEN 
  | 26 -> TOKEN_TRUE 
  | 27 -> TOKEN_CSTBOOL 
  | 28 -> TOKEN_NAME 
  | 29 -> TOKEN_CSTINT 
  | 32 -> TOKEN_end_of_input
  | 30 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_AtExpr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AppExpr 
    | 25 -> NONTERM_AppExpr 
    | 26 -> NONTERM_Const 
    | 27 -> NONTERM_Const 
    | 28 -> NONTERM_List 
    | 29 -> NONTERM_List 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 32 
let _fsyacc_tagOfErrorTerminal = 30

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | COMMA  -> "COMMA" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | LBRACK  -> "LBRACK" 
  | RBRACK  -> "RBRACK" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | AT  -> "AT" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | LBRACK  -> (null : System.Object) 
  | RBRACK  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | AT  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 24us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 32us; 14us; 33us; 15us; 34us; 16us; 35us; 17us; 36us; 18us; 37us; 19us; 38us; 20us; 39us; 21us; 40us; 22us; 41us; 23us; 42us; 24us; 43us; 25us; 48us; 26us; 49us; 27us; 52us; 28us; 53us; 29us; 55us; 30us; 57us; 31us; 64us; 31us; 26us; 65535us; 0us; 4us; 4us; 60us; 5us; 61us; 6us; 4us; 8us; 4us; 10us; 4us; 12us; 4us; 32us; 4us; 33us; 4us; 34us; 4us; 35us; 4us; 36us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 42us; 4us; 43us; 4us; 48us; 4us; 49us; 4us; 52us; 4us; 53us; 4us; 55us; 4us; 57us; 4us; 64us; 4us; 24us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 12us; 5us; 32us; 5us; 33us; 5us; 34us; 5us; 35us; 5us; 36us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 42us; 5us; 43us; 5us; 48us; 5us; 49us; 5us; 52us; 5us; 53us; 5us; 55us; 5us; 57us; 5us; 64us; 5us; 26us; 65535us; 0us; 44us; 4us; 44us; 5us; 44us; 6us; 44us; 8us; 44us; 10us; 44us; 12us; 44us; 32us; 44us; 33us; 44us; 34us; 44us; 35us; 44us; 36us; 44us; 37us; 44us; 38us; 44us; 39us; 44us; 40us; 44us; 41us; 44us; 42us; 44us; 43us; 44us; 48us; 44us; 49us; 44us; 52us; 44us; 53us; 44us; 55us; 44us; 57us; 44us; 64us; 44us; 2us; 65535us; 57us; 58us; 64us; 65us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 28us; 55us; 80us; 107us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 13us; 1us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 1us; 2us; 2us; 24us; 2us; 3us; 25us; 1us; 4us; 13us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 4us; 13us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 4us; 13us; 4us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 1us; 5us; 13us; 5us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 20us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 20us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 21us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 21us; 13us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 22us; 14us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 28us; 29us; 1us; 6us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 2us; 20us; 21us; 2us; 20us; 21us; 1us; 20us; 1us; 20us; 1us; 20us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 26us; 1us; 27us; 1us; 29us; 1us; 29us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 18us; 20us; 23us; 26us; 28us; 42us; 44us; 58us; 60us; 74us; 76us; 90us; 104us; 118us; 132us; 146us; 160us; 174us; 188us; 202us; 216us; 230us; 244us; 258us; 272us; 286us; 300us; 314us; 328us; 343us; 345us; 347us; 349us; 351us; 353us; 355us; 357us; 359us; 361us; 363us; 365us; 367us; 369us; 371us; 374us; 377us; 379us; 381us; 383us; 385us; 387us; 389us; 391us; 393us; 395us; 397us; 399us; 401us; 403us; 405us; 407us; 409us; 411us; |]
let _fsyacc_action_rows = 66
let _fsyacc_actionTableElements = [|8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 0us; 49152us; 13us; 32768us; 0us; 3us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 0us; 16385us; 6us; 16386us; 2us; 55us; 4us; 57us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 6us; 16387us; 2us; 55us; 4us; 57us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 13us; 32768us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 25us; 8us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 13us; 32768us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 18us; 10us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 12us; 16388us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 3us; 16389us; 14us; 35us; 15us; 36us; 16us; 37us; 3us; 16390us; 14us; 35us; 15us; 36us; 16us; 37us; 3us; 16391us; 14us; 35us; 15us; 36us; 16us; 37us; 3us; 16392us; 14us; 35us; 15us; 36us; 16us; 37us; 0us; 16393us; 0us; 16394us; 0us; 16395us; 10us; 16396us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 10us; 16397us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 6us; 16398us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 6us; 16399us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 6us; 16400us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 6us; 16401us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 13us; 32768us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 22us; 49us; 13us; 32768us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 19us; 50us; 13us; 32768us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 22us; 53us; 13us; 32768us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 19us; 54us; 13us; 32768us; 3us; 56us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 13us; 16412us; 1us; 64us; 6us; 38us; 7us; 39us; 8us; 40us; 9us; 41us; 10us; 42us; 11us; 43us; 12us; 32us; 13us; 34us; 14us; 35us; 15us; 36us; 16us; 37us; 17us; 33us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 0us; 16402us; 0us; 16403us; 1us; 32768us; 28us; 47us; 2us; 32768us; 6us; 48us; 28us; 51us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 0us; 16404us; 1us; 32768us; 6us; 52us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 0us; 16405us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 0us; 16406us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 1us; 32768us; 5us; 59us; 0us; 16407us; 0us; 16408us; 0us; 16409us; 0us; 16410us; 0us; 16411us; 8us; 32768us; 2us; 55us; 4us; 57us; 13us; 12us; 21us; 6us; 23us; 46us; 27us; 63us; 28us; 45us; 29us; 62us; 0us; 16413us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 9us; 10us; 24us; 25us; 32us; 39us; 48us; 62us; 71us; 85us; 94us; 107us; 116us; 120us; 124us; 128us; 132us; 133us; 134us; 135us; 146us; 157us; 164us; 171us; 178us; 185us; 199us; 213us; 227us; 241us; 255us; 269us; 278us; 287us; 296us; 305us; 314us; 323us; 332us; 341us; 350us; 359us; 368us; 377us; 378us; 379us; 381us; 384us; 393us; 402us; 403us; 405us; 414us; 423us; 424us; 433us; 434us; 443us; 445us; 446us; 447us; 448us; 449us; 450us; 459us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 3us; 2us; 2us; 1us; 1us; 1us; 3us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; 6us; 6us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16402us; 16403us; 65535us; 65535us; 65535us; 65535us; 16404us; 65535us; 65535us; 65535us; 16405us; 65535us; 16406us; 65535us; 65535us; 16407us; 16408us; 16409us; 16410us; 16411us; 65535us; 16413us; |]
let _fsyacc_reductions ()  =    [| 
# 279 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 288 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "FunPar.fsy"
                                                               _1 
                   )
# 35 "FunPar.fsy"
                 : Absyn.expr));
# 299 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 310 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               _1                     
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 321 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 334 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 345 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 357 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("@",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 369 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 381 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 393 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 405 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 417 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 429 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 441 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 453 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 465 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 477 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 489 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               _1                     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 500 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Var _1                 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 511 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 524 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 538 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               _2                     
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 549 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'List)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "FunPar.fsy"
                                                               List(_2)               
                   )
# 63 "FunPar.fsy"
                 : Absyn.expr));
# 560 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 572 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 68 "FunPar.fsy"
                 : Absyn.expr));
# 584 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
# 595 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 73 "FunPar.fsy"
                 : Absyn.expr));
# 606 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "FunPar.fsy"
                                                              [_1]                   
                   )
# 77 "FunPar.fsy"
                 : 'List));
# 617 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'List)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "FunPar.fsy"
                                                              _1 :: _3               
                   )
# 78 "FunPar.fsy"
                 : 'List));
|]
# 630 "FunPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 33;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
