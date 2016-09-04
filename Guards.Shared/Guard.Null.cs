using Guards.Extensions;
using System;
using System.Linq.Expressions;

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentNotNull(() => someParam)
        /// </example>
        /// <param name="expression">An expression containing a single string parameter e.g. () => someParam</param>
        public static void ArgumentNull<T>([ValidatedNotNull]Expression<Func<T>> expression)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentNull(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentNotNull(value, "value")
        /// </example>
        public static void ArgumentNull<T>([ValidatedNotNull]T value, string paramName)
        {
            if (value != null)
            {
                throw new ArgumentException(ExceptionMessages.ArgumentMustBeNull, paramName);
            }
        }

        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentNotNull(() => someParam)
        /// </example>
        /// <param name="expression">An expression containing a single string parameter e.g. () => someParam</param>
        public static void ArgumentNotNull<T>([ValidatedNotNull]Expression<Func<T>> expression)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentNotNull(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentNotNull(value, "value")
        /// </example>
        public static void ArgumentNotNull<T>([ValidatedNotNull]T value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, ExceptionMessages.ArgumentMustNotBeNull);
            }
        }
    }
}