using System;
using System.Collections.Generic;

namespace Library.Algorithm.ShuntingYard
{
    public enum TokenType
    {
        UNDEFINED,
        NUMBER,
        OPERATOR,
        LEFTPARENTHESIS,
        RIGHTPARENTHESIS,
        WHITESPACE,
        EQUAL
    }
}
