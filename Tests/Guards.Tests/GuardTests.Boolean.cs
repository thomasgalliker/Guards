using System;

using FluentAssertions;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentIsTrueThrowsArgumentExceptionIfIsFalse()
        {
            // Arrange
            bool argumentValue = false;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsTrue(() => argumentValue));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argumentValue");
            ex.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentIsFalseThrowsArgumentExceptionIfIsTrue()
        {
            // Arrange
            bool argumentValue = true;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentIsFalse(() => argumentValue));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argumentValue");
            ex.Message.Should().NotBeNullOrEmpty();
        }
    }
}