

namespace Guards
{
    public static class ExceptionMessages
    {
        public const string ArgumentMustBeInterface = "Type must be an interface.";
        public const string ArgumentMustNotBeInterface = "Type must not be an interface.";

        public const string ArgumentMustNotNull = "Argument must not be null.";
        public const string ArgumentMustNotBeEmpty = "Argument must not be empty.";
        public const string ArgumentMustBeNull = "Argument must be null.";

        public const string ArgumentIsTrue = "Argument must be true.";
        public const string ArgumentIsFalse = "Argument must be false.";

        public const string ArgumentIsGreaterThan = "Argument must be greater than {0}.";
        public const string ArgumentIsGreaterOrEqual = "Argument must be greater or equal to {0}.";
        public const string ArgumentIsLowerThan = "Argument must be lower than {0}.";
        public const string ArgumentIsLowerOrEqual = "Argument must be lower or equal to {0}.";
        public const string ArgumentIsBetween = "Argument must be between {0}{1} and {2}{3}.";
        public const string ArgumentIsNotNegative = "Provided number must not be negative.";
    }
}