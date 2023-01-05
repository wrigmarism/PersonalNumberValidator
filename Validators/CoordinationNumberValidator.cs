namespace ValidatePersonalNumber.Validators
{
    public sealed class CoordinationNumberValidator : BaseNumberValidator
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
            var dayChars = (number.Length > 11) ?
                number.Substring(6, 2) : number.Substring(4, 2);

            if (dayChars.All(char.IsDigit))
            {
                var dayDigits = int.Parse(dayChars);
                var result = dayDigits > 60 && dayDigits < 91;

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
                var result = int.Parse(monthDigits) <= 12;

                return result;
            }
            else
            {
                return false;
            }
        }
    }
}