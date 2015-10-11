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
            ArgumentNull(propertyValue, ((MemberExpression)expression.Body).Member.Name);
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
            ArgumentNotNull(propertyValue, ((MemberExpression)expression.Body).Member.Name);
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
                throw new ArgumentNullException(paramName, ExceptionMessages.ArgumentMustNotNull);
            }
        }

        /// <summary>
        ///     Checks if the given value is not null or empty.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentNotNull(() => stringParam)
        /// </example>
        /// <param name="expression">An expression containing a single string parameter e.g. () => stringParam</param>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]Expression<Func<string>> expression)
        {
            var compiledExpression = expression.Compile()();
            var paramName = ((MemberExpression)expression.Body).Member.Name;

            ArgumentNotNullOrEmpty(compiledExpression, paramName);
        }

        /// <summary>
        ///     Checks if the given value is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                ArgumentNotNull(value, paramName);

                throw new ArgumentException(ExceptionMessages.ArgumentMustNotBeEmpty, paramName);
            }
        }
    }
}