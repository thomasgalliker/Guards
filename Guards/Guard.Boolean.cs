using System;
using System.Linq.Expressions;
#if NETFX_CORE

#endif

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Checks if the given <paramref name="expression"/> is true.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="expression" /> parameter is false.</exception>
        public static void ArgumentIsTrue([ValidatedNotNull]Expression<Func<bool>> expression)
        {
            ArgumentIsTrueOrFalse(expression, throwCondition: false, exceptionMessage: ExceptionMessages.ArgumentIsFalse);
        }

        /// <summary>
        /// Checks if the given <paramref name="expression"/> is false.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="expression" /> parameter is true.</exception>
        public static void ArgumentIsFalse([ValidatedNotNull]Expression<Func<bool>> expression)
        {
            ArgumentIsTrueOrFalse(expression, throwCondition: true, exceptionMessage: ExceptionMessages.ArgumentIsTrue);
        }

        private static void ArgumentIsTrueOrFalse(Expression<Func<bool>> expression, bool throwCondition, string exceptionMessage)
        {
            ArgumentNotNull(() => expression);

            if (expression.Compile().Invoke() == throwCondition)
            {
                throw new ArgumentException(exceptionMessage, ((MemberExpression)expression.Body).Member.Name);
            }
        }
    }
}