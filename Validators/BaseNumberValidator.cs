namespace ValidatePersonalNumber.Validators
{
    public abstract class BaseNumberValidator : INumberValidator
    {
        public string FormatPersonalNumber(string number)
        {
            var result = "";

            foreach (var character in number)
            {
                if (char.IsDigit(character)) result += character;
            }

            return result.Length > 10 ? result.ToString()[^10..] : result;
        }

        public abstract bool ValidateCentury(string number);

        public abstract bool ValidateDay(string number);

        public abstract bool ValidateMonth(string number);

        public bool ValidateNumberLength(string number)
        {
            return number is not null && number.Length > 9 && number.Length < 14;
        }

        public bool ValidateSeparator(string number)
        {
            if (number.All(char.IsDigit)) return true;

            var indexOfSeparator = 0;

            if (number.Length == 11 || number.Length == 13)
            {
                if (number.Contains('-'))
                {
                    if (number.Contains('+')) return false;

                    indexOfSeparator = number.IndexOf('-');
                }

                if (number.Contains('+')) indexOfSeparator = number.IndexOf('+');
            }

            var result = indexOfSeparator == 6 || indexOfSeparator == 8;

            return result;
        }

        public bool ValidateVuhn(string number)
        {
            var digits = FormatPersonalNumber(number);

            var isValidLuhn = digits
                .All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9
                        ? thisNum - 9
                        : thisNum)
                ).Sum() % 10 == 0;

            return isValidLuhn;
        }
    }
}