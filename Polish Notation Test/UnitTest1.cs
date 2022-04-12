using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Polish_Notation_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PolishNotation_Calculate_CorrectInputData_SimpleExpression()
        {
            //Arrange
            string input = "+ 3 4";
            double expected = 7;

            // Act
            double result = PolishNotation.Calculate(input);
            // Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PolishNotation_Calculate_WrongInputData_LettersInInput()
        {
            //Arrange
            string input = "a+a +a 2a 3a 4a";
            string expected = "Wrong expression format";

            // Act
            try
            {
                PolishNotation.Calculate(input);
            }
            catch (System.Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, expected);
            }

        }

        [TestMethod]
        public void PolishNotation_Calculate_WrongInputData_invalidInputStructure()
        {
            //Arrange
            string input = "123 123 3 3 +++";
            string expected = "Wrong expression format";

            // Act
            try
            {
                PolishNotation.Calculate(input);
            }
            catch (System.Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, expected);
            }
        }

        [TestMethod]
        public void PolishNotation_Calculate_WrongInputData_EmptyString()
        {
            //Arrange
            string input = "";
            string expected = "Input string cannot be empty or WhiteSpace";

            // Act
            try
            {
                PolishNotation.Calculate(input);
            }
            catch (System.Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, expected);
            }
        }

        [TestMethod]
        public void PolishNotation_Calculate_CorrectInputData_HardExpression()
        {
            //Arrange
            string input = "/ + 4 4 + 2 2";
            double expected = 2;

            // Act
            double result = PolishNotation.Calculate(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PolishNotation_Calculate_CorrectInputData_SuperHardExpression()
        {
            //Arrange
            string input = "* / / + 4 4 + 1 1 / + 4 4 + 2 2 5";
            double expected = 10;

            // Act
            double result = PolishNotation.Calculate(input);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
