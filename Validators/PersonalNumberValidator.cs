namespace ValidatePersonalNumber.Validators
{
    public sealed class PersonalNumberValidator : BaseNumberValidator, INumberValidator
    {
        public override bool ValidateCentury(string number)
        {
            if (number.Length.Equals(12) || number.Length.Equals(13))
            {
                var result = number[..2].Equals("18") ||
                    number[..2].Equals("19") ||
                    number[..2].Equals("20");

                return result;
            }

            return true;
        }

        public override bool ValidateDay(string number)
        {
            var dayDigits = (number.Length > 11) ?
                number.Substring(6, 2) : number.Substring(4, 2);

            if (dayDigits.All(char.IsDigit))
            {
                var result = int.Parse(dayDigits) <= 31;

                return result;
            }
            else
            {
                return false;
            }
        }

        public override bool ValidateMonth(string number)
        {
            var monthDigits = (number.Length > 11) ?
                number.Substring(4, 2) : number.Substring(2, 2);

            if (monthDigits.All(char.IsDigit))
            {
                var digits = int.Parse(monthDigits);
                var result = digits > 0 && digits <= 12;

                return result;
            }
            else
            {
                return false;
            }
        }
    }
}