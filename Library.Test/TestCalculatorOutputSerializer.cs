using Calculator.Models;
using Library.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xunit;


namespace DbRepository.Test
{
    public class TestCalculatorOutputSerializer
    {
        [Fact]
        public void TestCalulatorOutput()
        {
            //  Arrange
            var inputList = new List<string> { "=", "5", "+", "3", "4" };
            var input = new CalculateInfixResponse() { CalculateStack = inputList };
            var count = input.CalculateStack.Count;

            var testInput = XMLSerializer<CalculateInfixResponse>.Serialize(input);

            //  Act
            var deserializeOutput = XMLSerializer<CalculateInfixResponse>.Deserialize(testInput);
            deserializeOutput.CalculateStack.Reverse();     //  Not necessary for test.  True Stack<T> has private indexer so use List.Reverse()

            //  Assert
            Assert.Equal(count, deserializeOutput.CalculateStack.Count);
        }
    }
}
