using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
#if NETFX_CORE
using System.Reflection;
#endif

namespace Guards
{
    [DebuggerStepThrough]
    public static class Guard
    {
        #region Boolean checks
        /// <summary>
        /// Checks if the given <paramref name="expression"/> is true.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="expression" /> parameter is false.</exception>
        public static void ArgumentIsTrue(Expression<Func<bool>> expression)
        {
            ArgumentIsTrueOrFalse(expression, throwCondition: false, exceptionMessage: ExceptionMessages.ArgumentIsFalse);
        }

        /// <summary>
        /// Checks if the given <paramref name="expression"/> is false.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="expression" /> parameter is true.</exception>
        public static void ArgumentIsFalse(Expression<Func<bool>> expression)
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
        #endregion

        #region Null checks
        /// <summary>
        ///     Only pass single parameters through to this call via the expression e.g. Guard.ArgumentNotNull(() => param);
        /// </summary>
        /// <typeparam name="T">The type of the parameter, inferred from the Expression</typeparam>
        /// <param name="expression">An expression containing a single parameter e.g. () => param</param>
        public static void ArgumentNotNull<T>(Expression<Func<T>> expression)
        {
            ArgumentNotNull(expression, "expression");

            // As seen here: http://jonfuller.codingtomusic.com/2008/12/11/static-reflection-method-guards/
            //var areEqual = EqualityComparer<T>.Default.Equals(expression.Compile()(), default(T));
            var propertyValue = expression.Compile()();
            ArgumentNotNull(propertyValue, ((MemberExpression)expression.Body).Member.Name);
        }

        public static void ArgumentNotNull<T>(T value, string paramName)
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
        ///     Only pass single parameters through to this call via the expression, e.g. Guard.ArgumentNotNull(() => stringParam)
        /// </example>
        /// <param name="expression">An expression containing a single string parameter e.g. () => stringParam</param>
        public static void ArgumentNotNullOrEmpty(Expression<Func<string>> expression)
        {
            var compiledExpression = expression.Compile()();
            var paramName = ((MemberExpression)expression.Body).Member.Name;

            ArgumentNotNullOrEmpty(compiledExpression, paramName);
        }

        /// <summary>
        ///     Checks if the given value is not null or empty.
        /// </summary>
        public static void ArgumentNotNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                ArgumentNotNull(value, paramName);

                throw new ArgumentException(ExceptionMessages.ArgumentMustNotEmpty, paramName);
            }
        }

        #endregion

        #region Numeric checks
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
        public static void ArgumentIsNotNegative(Expression<Func<int>> expression)
        {
            var argumentValue = expression.Compile()();
            ArgumentIsNotNegative(argumentValue, ((MemberExpression)expression.Body).Member.Name);
        }

        /// <summary>
        ///     Checks if <paramref name="argumentValue" /> is not a negative number.
        /// </summary>
        /// <param name="argumentValue">The value to verify.</param>
        /// <param name="argumentName">The name of the <paramref name="argumentValue" />.</param>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="argumentValue" /> parameter is a negative number.</exception>
        public static void ArgumentIsNotNegative(int argumentValue, string argumentName)
        {
            if (argumentValue < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentIsNotNegative));
            }
        }

        #endregion

        #region Reflective checks
        /// <summary>
        /// Checks if the given <paramref name="type"/> is an interface type.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="type" /> parameter is not an interface type.</exception>
        public static void ArgumentMustBeInterface(Type type)
        {
            CheckIfTypeIsInterface(type, false, ExceptionMessages.ArgumentMustBeInterface);
        }

        /// <summary>
        /// Checks if the given <paramref name="type"/> is not an interface type.
        /// </summary>
        /// <exception cref="ArgumentException">The <paramref name="type" /> parameter is an interface type.</exception>
        public static void ArgumentMustNotBeInterface(Type type)
        {
            CheckIfTypeIsInterface(type, true, ExceptionMessages.ArgumentMustNotBeInterface);
        }

        private static void CheckIfTypeIsInterface(Type type, bool throwIfItIsAnInterface, string exceptionMessage)
        {
#if NETFX_CORE
            if (type.GetTypeInfo().IsInterface == throwIfItIsAnInterface)
#else
            if (type.IsInterface == throwIfItIsAnInterface)
#endif
            {
                throw new ArgumentException(exceptionMessage, type.Name);
            }
        }
        #endregion
    }
}