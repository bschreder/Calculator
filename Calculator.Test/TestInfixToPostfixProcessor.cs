using Calculator.Business;
using Calculator.Models;
using Library.Algorithm;
using Library.Business;
using Xunit;

namespace Calculator.Test
{
    public class TestInfixToPostfixProcessor
    {
        [Theory]
        [InlineData("3+4=",3)]
        [InlineData("21-9=",3)]
        [InlineData("1*1",3)]
        [InlineData("1+1/1^1=",7)]
        [InlineData("1-(1+1)%1=",7)]
        [InlineData("1+2*2",5)]
        public void TestProcessor(string inputValue, int numItems)
        {
            //  Arrange
            var input = new CalculateInfixRequest()
            {
                Input = inputValue,
                Operators = new OperatorList().Operators,
            };

            //  Act
            BResult<CalculateInfixResponse> result = new InfixToPostfixProcessor().InfixToPostfix(input);

            //  Assert
            Assert.True(numItems == result.Result.CalculateStack.Count);
            Assert.Empty(result.Error);
        }

        [Theory]
        [InlineData("abc",0)]
        [InlineData("()3!4=",2)]
        [InlineData("1*()+1$",4)]
        [InlineData("(2+2()-1", 6)]     //  5 valid chars + 1 extra '('
        [InlineData("16*&21", 3)]
        public void TestProcessor_Bad(string inputValue, int numItems)
        {
            var input = new CalculateInfixRequest()
            {
                Input = inputValue,
                Operators = new OperatorList().Operators,
            };

            BResult<CalculateInfixResponse> result = new InfixToPostfixProcessor().InfixToPostfix(input);

            Assert.True(numItems == result.Result.CalculateStack.Count);
            Assert.NotEmpty(result.Error);
        }
    }
}
