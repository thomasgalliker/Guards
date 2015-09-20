
namespace Guards
{
    public static class ExceptionMessages
    {
        public const string ArgumentMustBeInterface = "Type must be an interface.";
        public const string ArgumentMustNotBeInterface = "Type must not be an interface.";
        public const string ArgumentIsNotNegative = "Provided number must not be negative.";

        public static string ArgumentMustNotNull = "Argument must not be null.";
        public static string ArgumentMustNotEmpty = "Argument must not be empty.";

        public static string ArgumentIsTrue = "Argument must be true.";
        public static string ArgumentIsFalse = "Argument must be false.";
    }
}