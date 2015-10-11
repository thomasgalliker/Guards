using System;
using System.Globalization;
using System.Linq.Expressions;

using Guards.Extensions;

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Checks if given argument is greater than given value.
        /// </summary>
        /// <param name="expression">Given argument</param>
        /// <param name="givenValue">Given value.</param>        
        public static void ArgumentIsGreaterThan<T>([ValidatedNotNull]Expression<Func<T>> expression, T givenValue) where T : struct, IComparable<T>
        {
            ArgumentNotNull(expression);

            var propertyValue = expression.Compile()();
            if (propertyValue.IsLessThanOrEqual(givenValue))
            {
                var memberName = ((MemberExpression)expression.Body).Member.Name;
                throw new ArgumentOutOfRangeException(memberName, propertyValue, string.Format(ExceptionMessages.ArgumentIsGreaterThan, givenValue));
            }
        }

        /// <summary>
        /// Checks if given argument is greater or equal to given value.
        /// </summary>
        /// <param name="argument">Given argument</param>
        /// <param name="givenValue">Given value.</param>   
        public static void ArgumentIsGreaterOrEqual<T>([ValidatedNotNull]Expression<Func<T>> argument, T givenValue) where T : struct, IComparable<T>
        {
            ArgumentNotNull(argument);

            var propertyValue = argument.Compile()();
            if (propertyValue.IsLessThan(givenValue))
            {
                var memberName = ((MemberExpression)argument.Body).Member.Name;
                throw new ArgumentOutOfRangeException(memberName, propertyValue, string.Format(ExceptionMessages.ArgumentIsGreaterOrEqual, givenValue));
            }
        }

        /// <summary>
        /// Checks if given argument is lower than given value.
        /// </summary>
        /// <param name="argument">Given argument</param>
        /// <param name="givenValue">Given value.</param>   
        public static void ArgumentIsLowerThan<T>([ValidatedNotNull]Expression<Func<T>> argument, T givenValue) where T : struct, IComparable<T>
        {
            ArgumentNotNull(argument);

            var propertyValue = argument.Compile()();
            if (propertyValue.IsGreaterOrEqual(givenValue))
            {
                var memberName = ((MemberExpression)argument.Body).Member.Name;
                throw new ArgumentOutOfRangeException(memberName, propertyValue, string.Format(ExceptionMessages.ArgumentIsLowerThan, givenValue));
            }
        }

        /// <summary>
        /// Checks if given argument is lower or equal to given value.
        /// </summary>
        /// <param name="argument">Given argument</param>
        /// <param name="givenValue">Given value.</param>   
        public static void ArgumentIsLowerOrEqual<T>([ValidatedNotNull]Expression<Func<T>> argument, T givenValue) where T : struct, IComparable<T>
        {
            ArgumentNotNull(argument);

            var propertyValue = argument.Compile()();
            if (propertyValue.IsGreaterThan(givenValue))
            {
                var memberName = ((MemberExpression)argument.Body).Member.Name;
                throw new ArgumentOutOfRangeException(memberName, propertyValue, string.Format(ExceptionMessages.ArgumentIsLowerOrEqual, givenValue));
            }
        }

        /// <summary>
        /// Checks if given argument is between given lower value and upper value.
        /// </summary>
        /// <param name="argument">Given argument</param>
        /// <param name="lowerBound"></param>
        /// <param name="upperBound"></param>
        /// <param name="inclusive">Inclusive lower bound value if <param name="inclusive">true</param>.</param>   
        public static void ArgumentIsBetween<T>([ValidatedNotNull]Expression<Func<T>> argument, T lowerBound, T upperBound, bool inclusive = false) where T : struct, IComparable<T>
        {
            ArgumentNotNull(argument);

            var propertyValue = argument.Compile()();
            if (!propertyValue.IsBetween(lowerBound, upperBound, inclusive))
            {
                var memberName = ((MemberExpression)argument.Body).Member.Name;
                throw new ArgumentOutOfRangeException(memberName, propertyValue, string.Format(ExceptionMessages.ArgumentIsBetween, inclusive ? "(" : "[", lowerBound, upperBound, inclusive ? ")" : "]"));
            }
        }

        [Obsolete]
        public static void ArgumentMustNotExceed(Expression<Func<string>> expression, int maxLength = int.MaxValue)
        {
            var stringValue = expression.Compile()();
            int length = stringValue.Length;
            if (length > maxLength)
            {
                var memberName = ((MemberExpression)expression.Body).Member.Name;
                throw new ArgumentException("Length must not exceed " + maxLength + " number of characters", memberName);
            }
        }

        /// <summary>
        ///     Verifies the <paramref name="expression" /> is not a negative number and throws an
        ///     <see cref="ArgumentOutOfRangeException" /> if it is a negative number.
        /// </summary>
        /// <param name="expression">An expression containing a single parameter e.g. () => param</param>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="expression" /> parameter is a negative number.</exception>
        public static void ArgumentIsNotNegative<T>([ValidatedNotNull]Expression<Func<T>> expression) where T : struct, IComparable<T>
        {
            ArgumentNotNull(expression);

            var argumentValue = expression.Compile()();
            ArgumentIsNotNegative(argumentValue, ((MemberExpression)expression.Body).Member.Name);
        }

        /// <summary>
        ///     Checks if <paramref name="argumentValue" /> is not a negative number.
        /// </summary>
        /// <param name="argumentValue">The value to verify.</param>
        /// <param name="argumentName">The name of the <paramref name="argumentValue" />.</param>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="argumentValue" /> parameter is a negative number.</exception>
        public static void ArgumentIsNotNegative<T>(T argumentValue, string argumentName) where T : struct, IComparable<T>
        {
            if (argumentValue.IsLessThan(default(T)))
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentIsNotNegative));
            }
        }
    }
}