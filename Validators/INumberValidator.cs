namespace ValidatePersonalNumber.Validators
{
    public interface INumberValidator
    {
        public string FormatPersonalNumber(string number);
        public abstract bool ValidateCentury(string number);
        public abstract bool ValidateDay(string number);
        public abstract bool ValidateMonth(string number);
        public bool ValidateSeparator(string number);
        public bool ValidateVuhn(string number);
        public bool ValidateNumberLength(string personalNumber);
    }
}