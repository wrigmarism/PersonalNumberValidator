namespace ValidatePersonalNumber.Validators
{
    public sealed class OrganisationNumberValidator : BaseNumberValidator, INumberValidator
    {
        public override bool ValidateCentury(string number)
        {
            if (number.Length.Equals(12) || number.Length.Equals(13))
            {
                var result = number[..2].Equals("16");

                return result;
            }

            return true;
        }

        public override bool ValidateDay(string number)
        {
            var dayDigits = (number.Length > 11) ?
                number.Substring(6, 2) : number.Substring(4, 2);

            var result = dayDigits.All(char.IsDigit);

            return result;
        }

        public override bool ValidateMonth(string number)
        {
            var monthDigits = (number.Length > 11) ?
                number.Substring(4, 2) : number.Substring(2, 2);

            if (monthDigits.All(char.IsDigit))
            {
                var result = int.Parse(monthDigits) >= 20;

                return result;
            }
            else
            {
                return false;
            }
        }
    }
}