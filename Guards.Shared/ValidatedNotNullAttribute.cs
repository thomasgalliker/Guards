using System;

namespace Guards
{
    /// <summary>
    /// ValidatedNotNullAttribute signals to static code analysis (CA1062)
    /// to trust that we're really checking the marked parameters for null references.
    /// </summary>
    public sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}
