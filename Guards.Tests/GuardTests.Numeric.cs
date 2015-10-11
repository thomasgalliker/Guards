using System;
using System.Collections.Generic;

using FluentAssertions;


using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentIsBetweenTestsWithInclusive()
        {
            // Arrange
            int lowerBound = 2;
            int upperBound = 8;

            // Act
            var exceptions = RunInBetweenTests(lowerBound, upperBound, inclusive: true);

            // Assert
            exceptions.Should().ContainKeys(0, 1, 9, 10);
        }

        [Fact]
        public void ArgumentIsBetweenTestsWithExclusive()
        {
            // Arrange
            int lowerBound = 2;
            int upperBound = 8;

            // Act
            var exceptions = RunInBetweenTests(lowerBound, upperBound, inclusive: false);

            // Assert
            exceptions.Should().ContainKeys(0, 1, 2, 8, 9, 10);
        }

        private static Dictionary<int, Exception> RunInBetweenTests(int lowerBound, int upperBound, bool inclusive)
        {
            var exceptions = new Dictionary<int, Exception>();

            // Act
            for (int i = lowerBound - 2; i <= upperBound + 2; i++)
            {
                try
                {
                    Guard.ArgumentIsBetween(() => i, lowerBound, upperBound, inclusive);
                }
                catch (Exception ex)
                {
                    exceptions.Add(i, ex);
                }
            }

            return exceptions;
        }

        [Fact]
        public void ArgumentIsNotNegativeThrowsIfArgumentIsNegative()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex1 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNotNegative(-1, argumentName));
            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNotNegative(-1, null));
            var ex3 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNotNegative(-1, string.Empty));

            // Assert
            Assert.Equal(argumentName, ex1.ParamName);
            Assert.Null(ex2.ParamName);
            Assert.Equal(string.Empty, ex3.ParamName);
        }

        [Fact]
        public void ArgumentIsNotNegativeThrowsIfArgumentIsNegativeWithExpression()
        {
            // Arrange
            int argumentValue = -1;

            // Act
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNotNegative(() => argumentValue));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argumentValue");
            ex.Message.Should().NotBeNullOrEmpty();
        }
    }
}