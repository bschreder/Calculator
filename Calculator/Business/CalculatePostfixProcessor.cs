using Calculator.Interfaces;
using Calculator.Models;
using Library.Algorithm;
using Library.Algorithm.ShuntingYard;
using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Calculator.Business
{
    public class CalculatePostfixProcessor
    {
        /// <summary>
        /// Calculate output of postfix expression
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public BResult<CalculatePostfixResponse> Calculate(CalculatePostfixRequest inputValue)
        {
            var result = new BResult<CalculatePostfixResponse>() { Result = new CalculatePostfixResponse() };
            var stack = new Stack<string>();
            IDictionary<string, Operator> operators = inputValue.Operators;
            IDictionary<string, Type> mathOperators = GetMathOperators(operators);

            foreach (string token in inputValue.CalculateStack)
            {

                var tType = TokenHelper.GetTokenType(token, operators);

                switch (tType)
                {
                    case TokenType.NUMBER:
                        stack.Push(token);
                        break;

                    case TokenType.OPERATOR:
                        string rightOperand = stack.Pop();
                        string leftOperand = stack.Pop();

                        Type operatorType = mathOperators.Where(k => k.Key.Equals(token)).Select(v => v.Value).FirstOrDefault();
                        var obj = Activator.CreateInstance(operatorType) as IMathOperator<CalculatePostfixResponse>;
                        BResult<CalculatePostfixResponse> br = obj.MathOperator(leftOperand, rightOperand);
                        result.Error.AddRange(br.Error);

                        stack.Push(br.Result.CalculatedValue.ToString());
                        break;

                    case TokenType.UNDEFINED:
                    case TokenType.LEFTPARENTHESIS:
                    case TokenType.RIGHTPARENTHESIS:
                    case TokenType.EQUAL:
                    case TokenType.WHITESPACE:
                    default:
                        result.Error.Add(new HError("Calculate", $"Unknown TokenType: {tType}"));
                        break;
                }

            }

            result.Result.CalculatedValue = Convert.ToInt32(stack.Pop());
            return result;
        }


        private IDictionary<string, Type> GetMathOperators(IDictionary<string, Operator> operators)
        {
            IEnumerable<Type> mathOperators = Assembly.GetAssembly(typeof(CalculateProcessor))
                                                .GetExportedTypes()
                                                .Where(i => i.GetInterfaces().Any(it => it.Name.Contains("IMathOperator")));

            var returnDictionary = new Dictionary<string, Type>();

            foreach (KeyValuePair<string, Operator> op in operators)
            {
                Type mathOperatorType = mathOperators.Where(t => t.Name.ToUpper().StartsWith(op.Value.Name.ToUpper())).FirstOrDefault();
                if (mathOperatorType != null)
                    returnDictionary.Add(op.Key.ToUpper(), mathOperatorType);
            }

            return returnDictionary;
        }
    }
}