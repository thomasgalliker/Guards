using System;
using System.Linq.Expressions;

using Guards.Extensions;

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        ///     Checks if the given string is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]Expression<Func<string>> expression)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentNotNullOrEmpty(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given string is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                ArgumentNotNull(value, paramName);

                throw new ArgumentException(ExceptionMessages.ArgumentMustNotBeEmpty, paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has the expected length
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="expectedLength"></param>
        public static void ArgumentHasLength([ValidatedNotNull]Expression<Func<string>> expression, int expectedLength)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            int length = propertyValue.Length;
            if (length != expectedLength)
            {
                var paramName = expression.GetMemberName();
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasLength, expectedLength, length), paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has a length which exceeds given max length.
        /// </summary>
        public static void ArgumentHasMaxLength([ValidatedNotNull]Expression<Func<string>> expression, int maxLength)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            int length = propertyValue.Length;
            if (length > maxLength)
            {
                var paramName = expression.GetMemberName();
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasMaxLength, maxLength), paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has a length which is at least given min length long.
        /// </summary>
        public static void ArgumentHasMinLength([ValidatedNotNull]Expression<Func<string>> expression, int minLength)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            int length = propertyValue.Length;
            if (length < minLength)
            {
                var paramName = expression.GetMemberName();
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasMinLength, minLength), paramName);
            }
        }

        [Obsolete("Use ArgumentHasMaxLength instead.")]
        public static void ArgumentMustNotExceed(Expression<Func<string>> expression, int maxLength = int.MaxValue)
        {
            throw new NotSupportedException("This method is no longer supported. Use ArgumentHasMaxLength instead.");
        }
    }
}