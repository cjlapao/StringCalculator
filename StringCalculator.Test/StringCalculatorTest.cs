using System;
using Xunit;
using Moq;
using Calculator.Core;

namespace Calculator.test
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyString()
        {
            StringCalculator calc = new StringCalculator();

            string simpleInput = "";
            int result = calc.Add(simpleInput);

            Assert.Equal(0,result);
        }

        [Fact]
        public void SimpleAdd()
        {
            StringCalculator calc = new StringCalculator();

            string simpleInput = "1,\n2,3";
            int result = calc.Add(simpleInput);

            Assert.Equal(6, result);
        }

        [Fact]
        public void MultipleLinesAdd()
        {
            StringCalculator calc = new StringCalculator();

            string simpleInput = "1,\n2,3\n4,5";
            int result = calc.Add(simpleInput);

            Assert.Equal(15, result);
        }

        [Fact]
        public void DifferentDelimitersAdd()
        {
            StringCalculator calc = new StringCalculator();

            string inputString = "//;\n1;2";
            int result = calc.Add(inputString);

            Assert.Equal(3, result);
        }

        [Fact]
        public void DifferentDelimitersMultipleLinesAdd()
        {
            StringCalculator calc = new StringCalculator();

            string inputString = "//;\n1;2;3\n4";
            int result = calc.Add(inputString);

            Assert.Equal(10, result);
        }

        [Fact]
        public void GreaterThanThousandAdd()
        {
            StringCalculator calc = new StringCalculator();

            string inputString = "//;\n2;10001;13";
            int result = calc.Add(inputString);

            Assert.Equal(15, result);
        }

        [Fact]
        public void ComplexDelimiterAdd()
        {
            StringCalculator calc = new StringCalculator();

            string inputString = "//*%\n1*2%3";
            int result = calc.Add(inputString);

            Assert.Equal(6, result);
        }

        [Fact]
        public void InvalidInput()
        {
            StringCalculator calc = new StringCalculator();

            string invalidInput = "1,\n";

            Assert.Throws<InvalidInputException>(() => calc.Add(invalidInput));
        }

        [Fact]
        public void NegativeNumbers()
        {
            StringCalculator calc = new StringCalculator();

            string invalidInput = "1,\n-2,5,6";

            Assert.Throws<NegativeNotAllowedException>(() => calc.Add(invalidInput));
        }

        [Fact]
        public void NegativeListNumbers()
        {
            StringCalculator calc = new StringCalculator();

            string invalidInput = "1,\n-2,-5,6";

            Exception e = Assert.Throws<NegativeNotAllowedException>(() => calc.Add(invalidInput));
            Assert.Contains("-2, -5", e.Message);
        }
    }
}
