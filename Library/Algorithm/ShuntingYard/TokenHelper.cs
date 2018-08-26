using System;
using System.Collections.Generic;

namespace Library.Algorithm.ShuntingYard
{
    public class TokenHelper
    {
        public static TokenType GetTokenType(string token, IDictionary<string, Operator> operators)
        {
            if (int.TryParse(token, out _)) return TokenType.NUMBER;
            if (operators.ContainsKey(token)) return TokenType.OPERATOR;
            if (string.IsNullOrWhiteSpace(token)) return TokenType.WHITESPACE;

            char ch = token[0];
            if (ch == '(') return TokenType.LEFTPARENTHESIS;
            if (ch == ')') return TokenType.RIGHTPARENTHESIS;
            if (ch == '=') return TokenType.EQUAL;

            return TokenType.UNDEFINED;
        }
    }
}
