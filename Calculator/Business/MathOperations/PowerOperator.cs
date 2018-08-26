using Calculator.Interfaces;
using Calculator.Models;
using Library.Business;
using Library.Model;
using System;

namespace Calculator.Business.MathOperations
{
    public class PowerOperator : IMathOperator<CalculatePostfixResponse>
    {
        public BResult<CalculatePostfixResponse> MathOperator(string leftOperand, string rightOperand)
        {
            var result = new BResult<CalculatePostfixResponse>() { Result = new CalculatePostfixResponse() };

            if (!int.TryParse(leftOperand, out int lOperand))
                result.Error.Add(new HError("PowerOperator", $"leftOperand ({leftOperand}) is not an integer"));
            if (!int.TryParse(rightOperand, out int rOperand))
                result.Error.Add(new HError("PowerOperator", $"rightOperand ({rightOperand}) is not an integer"));

            if (result.Error.Count == 0)
                result.Result.CalculatedValue = Convert.ToInt32(Math.Pow(lOperand, rOperand));

            return result;
        }
    }
}