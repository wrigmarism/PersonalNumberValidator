using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatePersonalNumber.Validators;

namespace ValidatePersonalNumber.Test.Validators
{
    [TestClass]
    public sealed class OrganisationNumberValidatorTest
    {
        private readonly OrganisationNumberValidator organisationNumberValidator;

        public OrganisationNumberValidatorTest()
        {
            organisationNumberValidator = new OrganisationNumberValidator();
        }

        [TestMethod]
        public void Should_return_false_from_ValidateCentury()
        {
            // Arrange
            var number = "19XXXXXXXXXX";

            // Act
            var result = organisationNumberValidator.ValidateCentury(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_return_true_from_ValidateCentury()
        {
            // Arrange
            var number = "16XXXXXXXXXX";

            // Act
            var result = organisationNumberValidator.ValidateCentury(number);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_return_false_from_ValidateMonthForOrganisationNumber()
        {
            // Arrange
            var number = "XX10XXXXXX";

            // Act
            var result = organisationNumberValidator.ValidateMonth(number);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_return_true_from_ValidateMonthForOrganisationNumber()
        {
            // Arrange
            var number = "XX66XXXXXX";

            // Act
            var result = organisationNumberValidator.ValidateMonth(number);

            // Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("556614-318")]
        [DataRow("556614-318X")]
        public void Should_return_false_if_not_valid_number_of_digits(string number)
        {
            // Act
            var result = organisationNumberValidator.FormatPersonalNumber(number);

            // Assert
            Assert.IsFalse(result.Length == 10);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void Should_return_false_if_null_or_empty(string number)
        {
            // Act
            var result = organisationNumberValidator.ValidateNumberLength(number);

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("556614-3185")]
        [DataRow("16556601-6399")]
        [DataRow("262000-1111")]
        [DataRow("857202-7566")]
        public void Should_return_true_if_valid(string number)
        {
            // Act
            var result = organisationNumberValidator.ValidateNumberLength(number);

            // Assert
            Assert.IsTrue(result);
        }


    }
}