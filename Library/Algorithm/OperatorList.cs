using System.Collections.Generic;

namespace Library.Algorithm
{
    public class OperatorList
    {
        public IDictionary<string, Operator> Operators => new Dictionary<string, Operator>
        {
            ["+"] = new Operator { Name = "Addition", Symbol = "+", Precedence = 2, RightAssociative = false },
            ["-"] = new Operator { Name = "Subtraction", Symbol = "-", Precedence = 2, RightAssociative = false },
            ["*"] = new Operator { Name = "Multiplication", Symbol = "*", Precedence = 3, RightAssociative = false },
            ["/"] = new Operator { Name = "Division", Symbol = "/", Precedence = 3, RightAssociative = false },
            ["%"] = new Operator { Name = "Modulus", Symbol = "%", Precedence = 3, RightAssociative = false },
            ["^"] = new Operator { Name = "Power", Symbol = "^", Precedence = 4, RightAssociative = true }
        };
    }
}