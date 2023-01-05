using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatePersonalNumber.Validators;

namespace ValidatePersonalNumber.Test.Validators
{
    [TestClass]
    public sealed class PersonalNumberValidatorTest
    {
        private readonly PersonalNumberValidator personalNumberValidator;

        public PersonalNumberValidatorTest()
        {
            personalNumberValidator = new PersonalNumberValidator();
        }

        [TestMethod]
        [DataRow("18XXXXXXXXXX")]
        [DataRow("19XXXXXXXXXX")]
        [DataRow("20XXXXXXXXXX")]
        public void Should_return_true_from_ValidateCentury(string number)
        {
            // Act
            var result = personalNumberValidator.ValidateCentury(number);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_return_false_from_ValidateDay()
        {
            // Arrange
            var number = "201701322384";

            // Act
            var result = personalNumberValidator.ValidateDay(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_return_true_from_ValidateDay()
        {
            // Arrange
            var number = "201701102384";

            // Act
            var result = personalNumberValidator.ValidateDay(number);

            // Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("20179123239")]
        [DataRow("20179123239X")]
        [DataRow("2017912323942")]
        public void Should_return_false_if_not_valid_number_of_digits(string number)
        {
            // Act
            var result = personalNumberValidator.FormatPersonalNumber(number);

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
            var result = personalNumberValidator.ValidateNumberLength(number);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("201701102384")]
        [DataRow("141206-2380")]
        [DataRow("20080903-2386")]
        [DataRow("7101169295")]
        [DataRow("198107249289")]
        [DataRow("19021214-9819")]
        [DataRow("190910199827")]
        [DataRow("191006089807")]
        [DataRow("192109099180")]
        [DataRow("4607137454")]
        [DataRow("194510168885")]
        [DataRow("900118+9811")]
        [DataRow("189102279800")]
        [DataRow("189912299816")]
        public void Should_return_true_if_valid_length(string number)
        {
            // Act
            var result = personalNumberValidator.ValidateNumberLength(number);

            // Assert
            Assert.IsTrue(result);
        }
    }
}