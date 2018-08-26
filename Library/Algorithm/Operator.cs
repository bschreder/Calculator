using System.Collections.Generic;

namespace Library.Algorithm
{
    public class Operator
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Precedence { get; set; }
        public bool RightAssociative { get; set; }
    }
}