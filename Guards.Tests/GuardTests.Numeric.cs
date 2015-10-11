using System;
using System.Collections.Generic;

using FluentAssertions;


using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentIsGreaterThanThrowsIfNotTrue()
        {
            // Arrange
            int testRangeFrom = 0;
            int testRangeTo = 10;
            int greaterThan = 5;

            // Act
            var testResults = RunTests(testRangeFrom, testRangeTo, i => Guard.ArgumentIsGreaterThan(() => i, greaterThan));

            // Assert
            testResults.Should().ContainKeys(0, 1, 2, 3, 4, 5);
        }

        [Fact]
        public void ArgumentIsGreaterOrEqualThrowsIfNotTrue()
        {
            // Arrange
            int testRangeFrom = 0;
            int testRangeTo = 10;
            int greaterOrEqual = 5;

            // Act
            var testResults = RunTests(testRangeFrom, testRangeTo, i => Guard.ArgumentIsGreaterOrEqual(() => i, greaterOrEqual));

            // Assert
            testResults.Should().ContainKeys(0, 1, 2, 3, 4);
        }

        [Fact]
        public void ArgumentIsLowerThanThrowsIfNotTrue()
        {
            // Arrange
            int testRangeFrom = 0;
            int testRangeTo = 10;
            int lowerThan = 5;

            // Act
            var testResults = RunTests(testRangeFrom, testRangeTo, i => Guard.ArgumentIsLowerThan(() => i, lowerThan));

            // Assert
            testResults.Should().ContainKeys(5, 6, 7, 8, 9, 10);
        }

        [Fact]
        public void ArgumentIsLowerOrEqualThrowsIfNotTrue()
        {
            // Arrange
            int testRangeFrom = 0;
            int testRangeTo = 10;
            int lowerOrEqual = 5;

            // Act
            var testResults = RunTests(testRangeFrom, testRangeTo, i => Guard.ArgumentIsLowerOrEqual(() => i, lowerOrEqual));

            // Assert
            testResults.Should().ContainKeys(6, 7, 8, 9, 10);
        }

        [Fact]
        public void ArgumentIsBetweenTestsWithInclusive()
        {
            // Arrange
            int testRangeFrom = 0;
            int testRangeTo = 10;
            int lowerBound = 2;
            int upperBound = 8;

            // Act
            var testResults = RunTests(testRangeFrom, testRangeTo, i => Guard.ArgumentIsBetween(() => i, lowerBound, upperBound, inclusive: true));

            // Assert
            testResults.Should().ContainKeys(0, 1, 9, 10);
        }

        [Fact]
        public void ArgumentIsBetweenTestsWithExclusive()
        {
            // Arrange
            int testRangeFrom = 0;
            int testRangeTo = 10;
            int lowerBound = 2;
            int upperBound = 8;

            // Act
            var testResults = RunTests(testRangeFrom, testRangeTo, i => Guard.ArgumentIsBetween(() => i, lowerBound, upperBound, inclusive: false));

            // Assert
            testResults.Should().ContainKeys(0, 1, 2, 8, 9, 10);
        }

        private static Dictionary<int, Exception> RunTests(int testRangeLowerBound, int testRangeUpperBound, Action<int> testAction)
        {
            var exceptions = new Dictionary<int, Exception>();

            for (int i = testRangeLowerBound; i <= testRangeUpperBound; i++)
            {
                try
                {
                    testAction(i);
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