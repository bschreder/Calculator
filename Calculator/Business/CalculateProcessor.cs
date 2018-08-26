using Calculator.Models;
using DbRepository.Business;
using DbRepository.Dtos;
using Library.Algorithm;
using Library.Business;
using Library.Interfaces;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Business
{
    public class CalculateProcessor : IBProcessor<BResult<CalculatorResponse>, CalculatorRequest>
    {
        private readonly DataRepository<ErrorDto> _herrorRepository = default(DataRepository<ErrorDto>);
        private readonly IDictionary<string, Operator> _operators = default(IDictionary<string, Operator>);

        public CalculateProcessor()
        {
            _herrorRepository = new DbFactory<ErrorDto>().CreateDbFactory();
            _operators = new OperatorList().Operators;
        }

        public async Task<BResult<CalculatorResponse>> ExecuteAsync(CalculatorRequest request)
        {
            BResult<CalculatorResponse> result = new BResult<CalculatorResponse> { Result = new CalculatorResponse() };

            try
            {
                if (string.IsNullOrWhiteSpace(request.Input))
                    result.Error.Add(new HError("Calculator", "Invalid request - null input"));
                if (request.Input.Any(c => char.IsLetter(c)))
                    result.Error.Add(new HError("Calculator", "Invalid input - contains letters"));
                if (!request.Input.EndsWith("="))
                    result.Error.Add(new HError("Calculator", "Invalid input - Expression must end with '='"));

                if (_operators == null || _operators.Count == 0)
                {
                    result.Error.Add(new HError("Calculator", "Invalid operator creation"));
                    return result;
                }

                //  Check input string against valid list of valid operators / digits
                List<char> goodChar = _operators.Keys.SelectMany(s => s.ToCharArray()).ToList();
                goodChar.AddRange(new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '=' });
                if (request.Input.Except(goodChar).Any())
                {
                    string validChar = string.Join(", ", goodChar.Select(c => c.ToString()).ToArray());
                    result.Error.Add(new HError("Calculator", $"Invalid input - Valid inputs are: {validChar}"));
                }

                if (result.Error.Count > 0)
                    return result;

                var calculateInputRequest = new CalculateInfixRequest() { Input = request.Input, Operators = _operators };
                BResult<CalculateInfixResponse> bResultInput = new InfixToPostfixProcessor().InfixToPostfix(calculateInputRequest);
                result.Error.AddRange(bResultInput.Error);
                //if (result.Error.Any())
                //    return result;

                var calulateOutputRequest = new CalculatePostfixRequest() { CalculateStack = bResultInput.Result.CalculateStack, Operators = _operators };
                BResult<CalculatePostfixResponse> bResultOutput = new CalculatePostfixProcessor().Calculate(calulateOutputRequest);
                result.Error.AddRange(bResultOutput.Error);
                result.Result.Output = bResultOutput.Result.CalculatedValue;

            }
            catch (Exception ex)
            {
                result.Error.Add(new HException(_herrorRepository, "Calculator", "Exception will executing Calculator", ex));
            }


            await Task.Delay(0);
            return result;
        }
    }
}