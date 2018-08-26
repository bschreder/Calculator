using Calculator.Interfaces;
using Calculator.Models;
using Library.Business;
using Library.Model;

namespace Calculator.Business.MathOperations
{
    public class SubtractionOperator : IMathOperator<CalculatePostfixResponse>
    {
        public BResult<CalculatePostfixResponse> MathOperator(string leftOperand, string rightOperand)
        {
            var result = new BResult<CalculatePostfixResponse>() { Result = new CalculatePostfixResponse() };

            if (!int.TryParse(leftOperand, out int lOperand))
                result.Error.Add(new HError("SubtractOperator", $"operand1 ({leftOperand}) is not an integer"));
            if (!int.TryParse(rightOperand, out int rOperand))
                result.Error.Add(new HError("SubtractOperator", $"operand2 ({rightOperand}) is not an integer"));

            if (result.Error.Count == 0)
                result.Result.CalculatedValue = lOperand - rOperand;

            return result;
        }
    }
}