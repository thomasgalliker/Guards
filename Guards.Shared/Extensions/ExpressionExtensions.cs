using System;
using System.Linq.Expressions;

namespace Guards.Extensions
{
    internal static class ExpressionExtensions
    {
        private static MemberExpression GetMemberExpression(this LambdaExpression lambdaExpression)
        {
            var memberExpression = lambdaExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("'lambdaExpression' should be a member expression");
            }

            return memberExpression;
        }

        public static string GetMemberName(this LambdaExpression lambdaExpression)
        {
            var memberExpression = GetMemberExpression(lambdaExpression);

            return memberExpression.Member.Name;
        }
    }
}
