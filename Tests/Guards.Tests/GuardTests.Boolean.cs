using System;

using FluentAssertions;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentIsTrue_ThrowsArgumentExceptionIfIsFalse()
        {
            // Arrange
            bool argumentValue = false;

            // Act
            var actions = new Action[]
            {
                () => Guard.ArgumentIsTrue(argumentValue, nameof(argumentValue)),
                () => Guard.ArgumentIsTrue(() => argumentValue)
            };

            // Assert
            foreach (var action in actions)
            {
                var ex = Assert.Throws<ArgumentException>(action);
                ex.ParamName.Should().BeEquivalentTo("argumentValue");
                ex.Message.Should().Be("Argument must be true.\r\nParameter name: argumentValue");
            }
        }

        [Fact]
        public void ArgumentIsFalse_ThrowsArgumentExceptionIfIsTrue()
        {
            // Arrange
            bool argumentValue = true;

            // Act
            var actions = new Action[]
            {
                () => Guard.ArgumentIsFalse(argumentValue, nameof(argumentValue)),
                () => Guard.ArgumentIsFalse(() => argumentValue)
            };

            // Assert
            foreach (var action in actions)
            {
                var ex = Assert.Throws<ArgumentException>(action);
                ex.ParamName.Should().BeEquivalentTo("argumentValue");
                ex.Message.Should().Be("Argument must be false.\r\nParameter name: argumentValue");
            }
        }
    }
}