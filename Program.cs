using ValidatePersonalNumber;
using ValidatePersonalNumber.Validators;

ValidityCheck validityCheck = new();

// Validity check for coordination numbers (samordningsnummer) that should pass
foreach (var number in TestNumbers.coordinationNumbersThatShouldPass)
{
    validityCheck.CoordinationNumberValidityCheck(number);
}

// Validity check for organisation numbers that should pass
foreach (var number in TestNumbers.organisationNumbersThatShouldPass)
{
    validityCheck.OrganisationNumberValidityCheck(number);
}

// Validity check for personal numbers that should fail
foreach (var number in TestNumbers.personalNumberThatShouldFail)
{
    validityCheck.PersonalNumberValidityCheck(number);
}

// Validity check for personal numbers that should pass
foreach (var number in TestNumbers.personalNumberThatShouldPass)
{
    validityCheck.PersonalNumberValidityCheck(number);
}

