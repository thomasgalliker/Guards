using System;
using System.Collections;
using System.Linq.Expressions;

namespace Guards
{
    public static partial class Guard
    {
        /// <summary>
        ///     Checks if the given string is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]Expression<Func<IEnumerable>> expression)
        {
            ArgumentNotNull(expression, "expression");

            var propertyValue = expression.Compile()();
            var paramName = ((MemberExpression)expression.Body).Member.Name;

            ArgumentNotNullOrEmpty(propertyValue, paramName);
        }

        /// <summary>
        ///     Checks if the given string is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty([ValidatedNotNull]IEnumerable enumerable, string paramName)
        {
            ArgumentNotNull(enumerable, paramName);

            bool hasElement = enumerable.GetEnumerator().MoveNext();
            if (!hasElement)
            {
                throw new ArgumentException(ExceptionMessages.ArgumentMustNotBeEmpty, paramName);
            }
        }
    }
}