using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatePersonalNumber.Validators;

namespace ValidatePersonalNumber.Test.Validators
{
    [TestClass]
    public sealed class CoordinationNumberValidatorTest
    {
        private readonly CoordinationNumberValidator coordinationNumberValidator;

        public CoordinationNumberValidatorTest()
        {
            coordinationNumberValidator = new CoordinationNumberValidator();
        }

        [TestMethod]
        public void Should_return_false_from_ValidateDay()
        {
            // Arrange
            var number = "XXXX01XXXX";

            // Act
            var result = coordinationNumberValidator.ValidateDay(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_return_true_from_ValidateDay()
        {
            // Arrange
            var number = "XXXX79XXXX";

            // Act
            var result = coordinationNumberValidator.ValidateDay(number);

            // Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("19091079982")]
        [DataRow("19091079982X")]
        [DataRow("200910799824")]
        public void Should_return_false_if_not_valid_number_of_digits(string number)
        {
            // Act
            var result = coordinationNumberValidator.FormatPersonalNumber(number);

            // Assert
            Assert.AreEqual(10, result.Length);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void Should_return_false_if_null_or_empty(string number)
        {
            // Act
            var result = coordinationNumberValidator.ValidateNumberLength(number);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("190910799824")]
        public void Should_return_true_if_valid(string number)
        {
            // Act
            var result = coordinationNumberValidator.ValidateNumberLength(number);

            // Assert
            Assert.IsTrue(result);
        }
    }
}