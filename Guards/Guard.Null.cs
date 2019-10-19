using System;
using System.Linq.Expressions;
using Guards.Internals.Extensions;

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentNull(() => someParam)
        /// </example>
        /// <param name="expression">An expression containing a single string parameter e.g. () => someParam</param>
        public static void ArgumentNull<T>([ValidatedNotNull]Expression<Func<T>> expression)
        {
            ArgumentNotNull(expression, nameof(expression));

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentNull(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Pass the parameter and it's name, e.g. Guard.ArgumentNull(someParam, nameof(someParam))
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
            ArgumentNotNull(expression, nameof(expression));

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentNotNull(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given value is not null.
        /// </summary>
        /// <example>
        ///     Pass the parameter and it's name, e.g. Guard.ArgumentNotNull(someParam, nameof(someParam))
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