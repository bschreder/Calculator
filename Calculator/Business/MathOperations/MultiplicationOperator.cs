using Calculator.Interfaces;
using Calculator.Models;
using Library.Business;
using Library.Model;

namespace Calculator.Business.MathOperations
{
    public class MultiplicationOperator : IMathOperator<CalculatePostfixResponse>
    {
        public BResult<CalculatePostfixResponse> MathOperator(string leftOperand, string rightOperand)
        {
            var result = new BResult<CalculatePostfixResponse>() { Result = new CalculatePostfixResponse() };

            if (!int.TryParse(leftOperand, out int lOperand))
                result.Error.Add(new HError("MultiplyOperator", $"leftOperand ({leftOperand}) is not an integer"));
            if (!int.TryParse(rightOperand, out int rOperand))
                result.Error.Add(new HError("MultiplyOperator", $"rightOperand ({rightOperand}) is not an integer"));

            if (result.Error.Count == 0)
                result.Result.CalculatedValue = lOperand * rOperand;

            return result;
        }
    }
}