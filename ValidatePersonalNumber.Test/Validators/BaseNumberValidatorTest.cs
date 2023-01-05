using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatePersonalNumber.Validators;

namespace ValidatePersonalNumber.Test.Validators
{
    [TestClass]
    public sealed class BaseNumberValidatorTest
    {
        private readonly PersonalNumberValidator baseNumberValidator;

        public BaseNumberValidatorTest()
        {
            baseNumberValidator = new PersonalNumberValidator();
        }

        [TestMethod]
        public void Should_format_number_correctly()
        {
            // Arrange
            var number = "20080903-2386";

            // Act
            var result = baseNumberValidator.FormatPersonalNumber(number);

            // Assert
            Assert.AreEqual("0809032386", result);
        }

        [TestMethod]
        public void Should_return_false_from_ValidateCentury()
        {
            // Arrange
            var number = "17XXXXXXXXXX";

            // Act
            var result = baseNumberValidator.ValidateCentury(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("XX13XXXXXX")]
        [DataRow("XXXX00XXXXXX")]
        public void Should_return_false_from_ValidateMonth(string number)
        {
            // Act
            var result = baseNumberValidator.ValidateMonth(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_return_true_from_ValidateMonth()
        {
            // Arrange
            var number = "7101169295";

            // Act
            var result = baseNumberValidator.ValidateMonth(number);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("20170110+-2384")]
        [DataRow("201701102384-")]
        [DataRow("201701102-384")]
        [DataRow("2017-01-10-2384")]
        public void Should_return_false_from_ValidateSeparator(string number)
        {
            // Act
            var result = baseNumberValidator.ValidateSeparator(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("201701102384")]
        [DataRow("20170110-2384")]
        [DataRow("20170110+2384")]
        [DataRow("170110-2384")]
        [DataRow("170110+2384")]
        public void Should_return_true_from_ValidateSeparator(string number)
        {
            // Act
            var result = baseNumberValidator.ValidateSeparator(number);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_return_false_from_ValidateVuhn()
        {
            // Arrange
            var number = "201701272394";

            // Act
            var result = baseNumberValidator.ValidateVuhn(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_return_true_from_ValidateVuhn()
        {
            // Arrange
            var number = "7101169295";

            // Act
            var result = baseNumberValidator.ValidateVuhn(number);

            // Assert
            Assert.IsTrue(result);
        }
    }
}