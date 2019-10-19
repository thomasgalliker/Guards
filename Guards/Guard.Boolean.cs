using System;
using System.Linq.Expressions;
using Guards.Internals.Extensions;

namespace Guards
{
    public static partial class Guard
    {
        public static void ArgumentIsTrue(bool value, string paramName)
        {
            if (!value)
            {
                throw new ArgumentException(ExceptionMessages.ArgumentMustBeTrue, paramName);
            }
        }

        public static void ArgumentIsFalse(bool value, string paramName)
        {
            if (value)
            {
                throw new ArgumentException(ExceptionMessages.ArgumentMustBeFalse, paramName);
            }
        }

        /// <summary>
        /// Checks if the given <paramref name="expression"/> is true.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="expression" /> parameter is false.</exception>
        public static void ArgumentIsTrue([ValidatedNotNull]Expression<Func<bool>> expression)
        {
            ArgumentIsTrueOrFalse(expression, throwCondition: false, exceptionMessage: ExceptionMessages.ArgumentMustBeTrue);
        }

        /// <summary>
        /// Checks if the given <paramref name="expression"/> is false.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="expression" /> parameter is true.</exception>
        public static void ArgumentIsFalse([ValidatedNotNull]Expression<Func<bool>> expression)
        {
            ArgumentIsTrueOrFalse(expression, throwCondition: true, exceptionMessage: ExceptionMessages.ArgumentMustBeFalse);
        }

        private static void ArgumentIsTrueOrFalse(Expression<Func<bool>> expression, bool throwCondition, string exceptionMessage)
        {
            ArgumentNotNull(expression, nameof(expression));

            if (expression.Compile().Invoke() == throwCondition)
            {
                var paramName = expression.GetMemberName();
                throw new ArgumentException(exceptionMessage, paramName);
            }
        }
    }
}