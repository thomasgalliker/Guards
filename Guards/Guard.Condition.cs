using System;
using System.Linq.Expressions;
using Guards.Extensions;

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        ///     Checks if the given value meets the given condition.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentCondition(() => value, v => true)
        /// </example>
        public static void ArgumentCondition<T>([ValidatedNotNull]Expression<Func<T>> expression, Expression<Func<T, bool>> condition)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            var paramName = expression.GetMemberName();

            ArgumentCondition(propertyValue, paramName, condition);
        }

        /// <summary>
        ///     Checks if the given value meets the given condition.
        /// </summary>
        /// <example>
        ///     Only pass single parameters through to this call via expression, e.g. Guard.ArgumentCondition(value, "value", v => true)
        /// </example>
        public static void ArgumentCondition<T>([ValidatedNotNull]T value, string paramName, Expression<Func<T, bool>> condition)
        {
            ArgumentNotNull(condition, "condition");

            if (!condition.Compile()(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ArgumentCondition, condition), paramName);
            }
        }
    }
}