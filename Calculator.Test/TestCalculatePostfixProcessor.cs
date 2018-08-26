using Calculator.Business;
using Calculator.Models;
using Library.Algorithm;
using Library.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
    public class TestCalculatePostfixProcessor
    {
        [Theory]
        [InlineData(new string[] { "3", "4", "+" }, 7)]
        [InlineData(new string[] { "4", "1", "-" }, 3)]
        [InlineData(new string[] { "2", "6", "*" }, 12)]
        [InlineData(new string[] { "4", "2", "/" }, 2)]
        [InlineData(new string[] { "2", "2", "^" }, 4)]
        [InlineData(new string[] { "2", "2", "%" }, 0)]
        public void TestProcessorSimple(string[] postfix, int result)
        {
            var request = new CalculatePostfixRequest()
            {
                CalculateStack = postfix.ToList(),
                Operators = new OperatorList().Operators
            };

            BResult<CalculatePostfixResponse> br = new CalculatePostfixProcessor().Calculate(request);

            Assert.Empty(br.Error);
            Assert.Equal(result, br.Result.CalculatedValue);
        }

        [Theory]
        [InlineData(new string[] { "2", "3", "*", "2", "2", "/", "+" }, 7)]
        [InlineData(new string[] { "2", "3", "2", "+", "*", "2", "/" }, 5)]
        [InlineData(new string[] { "7", "1", "-", "2", "/", "2", "^", "1", "-" }, 8)]
        [InlineData(new string[] { "2", "2", "^", "1", "-", "4", "2", "/", "7", "*", "+" }, 17)]
        public void TestProcessorComplex(string[] postfix, int result)
        {
            var request = new CalculatePostfixRequest()
            {
                CalculateStack = postfix.ToList(),
                Operators = new OperatorList().Operators
            };

            BResult<CalculatePostfixResponse> br = new CalculatePostfixProcessor().Calculate(request);

            Assert.Empty(br.Error);
            Assert.Equal(result, br.Result.CalculatedValue);
        }
    }
}
