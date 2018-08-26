using Calculator.Business;
using Calculator.Models;
using Library.Business;
using Xunit;

namespace Calculator.Test
{
    public class TestCalculateProcessor
    {
        [Theory]
        [InlineData("1+1=", 2)]
        [InlineData("1-2=", -1)]
        [InlineData("1*2=", 2)]
        [InlineData("1/1=", 1)]
        [InlineData("1%1=", 0)]
        [InlineData("1^1=", 1)]
        public async void TestProcessor(string infix, int value)
        {
            var request = new CalculatorRequest() { Input = infix };

            BResult<CalculatorResponse> result = await new CalculateProcessor().ExecuteAsync(request);

            Assert.Equal(value, result.Result.Output);
            Assert.Empty(result.Error);
        }

        [Theory]
        [InlineData("abc+xyz", 0)]
        [InlineData("1/0", 0)]
        [InlineData("1%0", 0)]
        [InlineData("1.2*3.2", 0)]
        public async void TestProcessor_BadInput(string infix, int value)
        {
            var request = new CalculatorRequest() { Input = infix };

            BResult<CalculatorResponse> result = await new CalculateProcessor().ExecuteAsync(request);

            Assert.Equal(value, result.Result.Output);
            Assert.NotEmpty(result.Error);
        }
    }
}
