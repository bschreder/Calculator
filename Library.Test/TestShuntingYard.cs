using Library.Algorithm;
using Library.Algorithm.ShuntingYard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.Test
{
    public class TestShuntingYard
    {
        [Theory]
        [InlineData("3+4 * 2/(1-5) ^2^3", 13)]
        [InlineData("31+4 * 12/(111-56) ^2^3", 13)]
        [InlineData("3+4*2/(1-5)^2^3 ", 13)]
        [InlineData("3 +14*2/(81-105)^02^213", 13)]
        [InlineData("1*1*1*1*1=",9)]        //  '=' is a whitespace
        [InlineData(" 8/2/2",5)]
        [InlineData("  ", 0)]
        [InlineData("1234", 1)]
        public void TestInfixCorrectInput(string input, int count)
        {
            var operators = new OperatorList().Operators;
            var result = new ShuntingYard().CreateReversePolishNotation(input, operators);

            Assert.Equal(count, result.Result.Count);
            Assert.Empty(result.Error);
        }

        [Theory]
        [InlineData("abc*xyz",1)]
        [InlineData(" =abc=xyz", 0)]
        public void TestInfixIncorrectInput(string input, int count)
        {
            var operators = new OperatorList().Operators;
            var result = new ShuntingYard().CreateReversePolishNotation(input, operators);

            Assert.Equal(count, result.Result.Count);
            Assert.NotEmpty(result.Error);
        }

        [Fact]
        public void TestInfixTrial()
        {
            var input = "2^2-1+3/2*7";
            var operators = new OperatorList().Operators;
            var result = new ShuntingYard().CreateReversePolishNotation(input, operators);

            //Assert.Equal(count, result.Result.Count);
            Assert.Empty(result.Error);
        }
    }
}
