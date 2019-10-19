
using System;

namespace Guards.Internals.Extensions
{
    internal static class ComparableExtensions
    {
        internal static bool IsGreaterThan<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) > 0;
        }

        internal static bool IsGreaterOrEqual<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) >= 0;
        }

        internal static bool IsLessThan<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) < 0;
        }

        internal static bool IsLessThanOrEqual<T>(this T value, T other) where T : IComparable<T>
        {
            return value.CompareTo(other) <= 0;
        }

        internal static bool IsBetween<T>(this T value, T lower, T upper, bool inclusive) where T : IComparable<T>
        {
            return (inclusive ? lower.IsLessThanOrEqual(value) : lower.IsLessThan(value)) &&
                   (inclusive ? value.IsLessThanOrEqual(upper) : value.IsLessThan(upper));
        }
    }
}
