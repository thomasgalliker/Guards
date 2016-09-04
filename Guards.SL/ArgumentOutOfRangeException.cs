namespace Guards
{
    public class ArgumentOutOfRangeException : System.ArgumentOutOfRangeException
    {
        public ArgumentOutOfRangeException(string paramName, object actualValue, string message) : base(paramName, message)
        {
            this.ActualValue = actualValue;
        }

        public object ActualValue { get; private set; }
    }
}
