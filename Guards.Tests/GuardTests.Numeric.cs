using System;

using FluentAssertions;


using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentIsNotNegativeThrowsIfArgumentIsNegative()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex1 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNotNegative(-1, argumentName));
            ArgumentException ex2 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.ArgumentIsNotNegative(-1, null));
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