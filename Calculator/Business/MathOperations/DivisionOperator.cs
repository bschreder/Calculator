using Calculator.Interfaces;
using Calculator.Models;
using Library.Business;
using Library.Model;

namespace Calculator.Business.MathOperations
{
    public class DivisionOperator : IMathOperator<CalculatePostfixResponse>
    {
        public BResult<CalculatePostfixResponse> MathOperator(string leftOperand, string rightOperand)
        {
            var result = new BResult<CalculatePostfixResponse>() { Result = new CalculatePostfixResponse() };

            if (!int.TryParse(leftOperand, out int lOperand))
                result.Error.Add(new HError("DivideOperator", $"leftOperand ({leftOperand}) is not an integer"));
            if (!int.TryParse(rightOperand, out int rOperand))
                result.Error.Add(new HError("DivideOperator", $"rightOperand ({rightOperand}) is not an integer"));
            if (rOperand == 0)
                result.Error.Add(new HError("DivideOperator", $"cannot divide by 0 - leftOperand: {leftOperand}, rightOperand: {rightOperand}"));

            if (result.Error.Count == 0)
                result.Result.CalculatedValue = lOperand / rOperand;

            return result;
        }
    }
}