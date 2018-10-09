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
            ArgumentNotNull(expression, nameof(expression));

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentNotNullOrEmpty(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given string is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]string propertyValue, string paramName)
        {
            if (string.IsNullOrEmpty(propertyValue))
            {
                ArgumentNotNull(propertyValue, paramName);

                throw new ArgumentException(ExceptionMessages.ArgumentMustNotBeEmpty, paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has the expected length
        /// </summary>
        /// <param name="expression">Property expression.</param>
        /// <param name="expectedLength">Expected length.</param>
        public static void ArgumentHasLength([ValidatedNotNull]Expression<Func<string>> expression, int expectedLength)
        {
            ArgumentNotNull(expression, nameof(expression));

            var propertyValue = expression.Compile()();
            int length = propertyValue.Length;
            if (length != expectedLength)
            {
                var paramName = expression.GetMemberName();
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasLength, expectedLength, length), paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has the expected length
        /// </summary>
        /// <param name="propertyValue">Property value.</param>
        /// <param name="paramName">Parameter name.</param>
        /// <param name="expectedLength">Expected length.</param>
        public static void ArgumentHasLength([ValidatedNotNull]string propertyValue, string paramName, int expectedLength)
        {
            ArgumentNotNull(propertyValue, paramName);

            int length = propertyValue.Length;
            if (length != expectedLength)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasLength, expectedLength, length), paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has a length which exceeds given max length.
        /// </summary>
        public static void ArgumentHasMaxLength([ValidatedNotNull]Expression<Func<string>> expression, int maxLength)
        {
            ArgumentNotNull(expression, nameof(expression));

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

             ArgumentHasMaxLength(propertyValue, paramName, maxLength);
        }

        /// <summary>
        /// Checks if the given string has a length which exceeds given max length.
        /// </summary>
        public static void ArgumentHasMaxLength([ValidatedNotNull]string propertyValue, string paramName, int maxLength)
        {
            ArgumentNotNull(propertyValue, paramName);

            int length = propertyValue.Length;
            if (length > maxLength)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasMaxLength, maxLength, length), paramName);
            }
        }

        /// <summary>
        /// Checks if the given string has a length which is at least given min length long.
        /// </summary>
        public static void ArgumentHasMinLength([ValidatedNotNull]Expression<Func<string>> expression, int minLength)
        {
            ArgumentNotNull(expression, nameof(expression));

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentHasMinLength(propertyValue, paramName, minLength);
        }

        /// <summary>
        /// Checks if the given string has a length which is at least given min length long.
        /// </summary>
        public static void ArgumentHasMinLength([ValidatedNotNull]string propertyValue, string paramName, int minLength)
        {
            ArgumentNotNull(propertyValue, paramName);

            var length = propertyValue.Length;
            if (length < minLength)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentHasMinLength, minLength, length), paramName);
            }
        }
    }
}