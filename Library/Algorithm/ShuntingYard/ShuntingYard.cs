using Library.Business;
using Library.Model;
using System.Collections.Generic;
using System.Text;

namespace Library.Algorithm.ShuntingYard
{
    //  https://en.wikipedia.org/wiki/Shunting-yard_algorithm
    public class ShuntingYard
    {
        private bool CompareOperators(Operator op1, Operator op2) =>
                op1.RightAssociative ? op1.Precedence < op2.Precedence : op1.Precedence <= op2.Precedence;

        private bool CompareOperators(IDictionary<string, Operator> opList, string op1, string op2) => 
                CompareOperators(opList[op1], opList[op2]);


        public BResult<List<string>> CreateReversePolishNotation(string infix, IDictionary<string, Operator> operators)
        {
            BResult<List<string>> result = new BResult<List<string>> { Result = default(List<string>) };
            List<string> output = new List<string>();
            Stack<string> op = new Stack<string>();

            for(int i=0; i< infix.Length; i++)
            {
                var ch = infix[i].ToString();
                var chType = TokenHelper.GetTokenType(ch, operators);

                switch (chType)
                {
                    case TokenType.NUMBER:                                              //  Get complete number and push on output stack
                        StringBuilder number = new StringBuilder(ch);
                        while (i < infix.Length-1)
                        {
                            ch = infix[i + 1].ToString();
                            if (TokenHelper.GetTokenType(ch, operators) == TokenType.NUMBER)
                            {
                                number.Append(ch);
                                i++;
                            }
                            else
                                break;
                        }
                        output.Add(number.ToString());
                        break;

                    case TokenType.OPERATOR:                                            //  Pop op w/ greater precedence then push current operator onto stack
                        while ( op.Count > 0 &&
                                TokenHelper.GetTokenType(op.Peek(), operators) != TokenType.LEFTPARENTHESIS && 
                                CompareOperators(operators, ch, op.Peek()) )
                            output.Add(op.Pop());
                        op.Push(ch);
                        break;

                    case TokenType.LEFTPARENTHESIS:                                     //  Push left parentheses
                        op.Push(ch);
                        break;

                    case TokenType.RIGHTPARENTHESIS:                                    //  Pop operators and push onto output until left parentheses is reached
                        while (op.Count > 0 && TokenHelper.GetTokenType(op.Peek(), operators) != TokenType.LEFTPARENTHESIS)
                            output.Add(op.Pop());
                        if (op.Count == 0)
                            result.Error.Add(new HError("ShuntingYard", "Mismatched parentheses"));
                        op.Pop();
                        break;

                    case TokenType.WHITESPACE:                                          //  Skip
                    case TokenType.EQUAL:
                        break;

                    case TokenType.UNDEFINED:                                           //  Indicate bad char
                    default:
                        result.Error.Add(new HError("ShuntingYard", $"Unknown TokenType: {chType}"));
                        break;
                }
            }

            while (op.Count > 0)                                                           // Pop remaining operators onto output stack 
            {
                if (TokenHelper.GetTokenType(op.Peek(), operators) == TokenType.LEFTPARENTHESIS)
                    result.Error.Add(new HError("ShuntingYard", "Mismatched parentheses"));
                output.Add(op.Pop());
            }

            result.Result = output;
            return result;
        }
    }
}
