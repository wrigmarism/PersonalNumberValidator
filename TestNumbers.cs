namespace ValidatePersonalNumber
{
    public record TestNumbers
    {
        public static readonly List<string> coordinationNumbersThatShouldPass = new()
        {
            "190910799824"
        };

        public static readonly List<string> organisationNumbersThatShouldPass = new()
        {
            "556614-3185",
            "16556601-6399",
            "262000-1111",
            "857202-7566"
        };

        public static readonly List<string> personalNumberThatShouldPass = new()
        { 
            "201701102384",
            "141206-2380",
            "20080903-2386",
            "7101169295",
            "198107249289",
            "19021214-9819",
            "190910199827",
            "191006089807",
            "192109099180",
            "4607137454",
            "194510168885",
            "900118+9811",
            "189102279800",
            "189912299816" 
        };

         public static readonly List<string> personalNumberThatShouldFail = new()
        {
            "201701272394",

            //Following number is marked as non-valid in the task, but is actually valid
            "190302299813"
        };
    }
}
