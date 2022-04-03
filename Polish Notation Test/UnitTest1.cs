using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace Polish_Notation_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PolishNotation_Calculate_CorrectInputData()
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
            string input = "++ 2 3 4asd";
            string expected = "Input string was not in a correct format.";

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
            string expected = "One of the identified items was in an invalid format";

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
            string expected = "Value cannot be null.";

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
    }
}
