using Calculator.Models;
using Library.Algorithm.ShuntingYard;
using Library.Business;
using Library.Model;

namespace Calculator.Business
{
    //  https://en.wikipedia.org/wiki/Shunting-yard_algorithm
    public class InfixToPostfixProcessor
    {
        /// <summary>
        /// Convert from infix to postfix notation
        /// </summary>
        /// <param name="request"></param>
        /// <returns>stack object for postfix calculator</returns>
        public BResult<CalculateInfixResponse> InfixToPostfix(CalculateInfixRequest request)
        {
            BResult<CalculateInfixResponse> result = new BResult<CalculateInfixResponse>() { Result = new CalculateInfixResponse() };

            if (request == null || string.IsNullOrWhiteSpace(request.Input) || request.Operators == null || request.Operators.Count == 0)
            {
                result.Error.Add(new HError("InfixToPostfix", "Invalid request"));
                return result;
            }

            var rpnResult = new ShuntingYard().CreateReversePolishNotation(request.Input, request.Operators);
            result.Error.AddRange(rpnResult.Error);
            result.Result.CalculateStack = rpnResult.Result;

            return result;
        }
    }
}