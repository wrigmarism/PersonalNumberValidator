namespace ValidatePersonalNumber.Validators
{
    public sealed class ValidityCheck
    {
        private const string CoordinationNumberType = "Coordination number";
        private const string OrganisationNumberType = "Organisation number";
        private const string PersonalNumberType = "Personal number";

        private const string NotAllCharactersAreDigits = "Not all characters are digits.";
        private const string WrongCenturyDigits = "The century digits are incorrect.";
        private const string WrongControlDigit = "The control digit is incorrect.";
        private const string WrongDayDigits = "The day digits are incorrect.";
        private const string WrongMonthDigits = "The month digits are incorrect.";
        private const string WrongNumberOfDigits = "The length of the number is incorrect.";

        INumberValidator coordinationNumberValidator = new CoordinationNumberValidator();
        INumberValidator organisationNumberValidator = new OrganisationNumberValidator();
        INumberValidator personalNumberValidator = new PersonalNumberValidator();

        public void CoordinationNumberValidityCheck(string number)
        {
            PatternValidityCheck(coordinationNumberValidator, number, CoordinationNumberType);
        }

        public void OrganisationNumberValidityCheck(string number)
        {
            PatternValidityCheck(organisationNumberValidator, number, OrganisationNumberType);
        }

        public void PersonalNumberValidityCheck(string number)
        {
            PatternValidityCheck(personalNumberValidator, number, PersonalNumberType);
        }

        private static bool CenturyValidityCheck(INumberValidator numberValidator, string number, string numberType)
        {
            if (numberValidator.ValidateCentury(number))
            {
                return true;
            }

            Console.WriteLine($"{numberType}: {number} - {WrongCenturyDigits}");

            return false;
        }

        private static bool DayValidityCheck(INumberValidator numberValidator, string number, string numberType)
        {
            if (numberValidator.ValidateDay(number))
            {
                return true;
            }

            Console.WriteLine($"{numberType}: {number} - {WrongDayDigits}");

            return false;
        }

        private static bool MonthValidityCheck(INumberValidator numberValidator, string number, string numberType)
        {
            if (numberValidator.ValidateMonth(number))
            {
                return true;
            }

            Console.WriteLine($"{numberType}: {number} - {WrongMonthDigits}");

            return false;
        }

        private static bool NumberLengthValidityCheck(INumberValidator numberValidator, string number, string numberType)
        {
            if (numberValidator.ValidateNumberLength(number))
            {
                return true;
            }

            Console.WriteLine($"{numberType}: {number} - {WrongNumberOfDigits}");

            return false;
        }

        private static void PatternValidityCheck(INumberValidator numberValidator, string number, string numberType)
        {
            if (NumberLengthValidityCheck(numberValidator, number, number))
            {
                var digits = numberValidator.FormatPersonalNumber(number);

                if (digits.Length == 10)
                {
                    _ = CenturyValidityCheck(numberValidator, digits, numberType) &&
                        DayValidityCheck(numberValidator, digits, numberType) &&
                        MonthValidityCheck(numberValidator, digits, numberType) &&
                        VuhnValidityCheck(numberValidator, digits, numberType);
                }
                else
                {
                    Console.WriteLine($"{numberType}: {number} - {NotAllCharactersAreDigits}");
                }

            }
        }

        private static bool VuhnValidityCheck(INumberValidator numberValidator, string number, string numberType)
        {
            if (numberValidator.ValidateVuhn(number))
            {
                return true;
            }

            Console.WriteLine($"{numberType}: {number} - {WrongControlDigit}");

            return false;
        }
    }
}