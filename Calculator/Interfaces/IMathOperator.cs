using Library.Algorithm;
using Library.Algorithm.ShuntingYard;
using Library.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IMathOperator<TResult> where TResult : class, new()
    {
        BResult<TResult> MathOperator(string leftOperand, string rightOperand);
    }
}
