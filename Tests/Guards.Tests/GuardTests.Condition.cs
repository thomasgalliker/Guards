using System;

using FluentAssertions;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ShouldThrowArgumentExceptionIfGivenConditionIsFalse()
        {
            // Arrange
            const bool TestProp = true;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentCondition(TestProp, nameof(TestProp), b => b == false));

            // Assert
            ex.ParamName.Should().Be("TestProp");
            ex.Message.Should().Contain("Given condition \"b => (b == False)\" is not met.");
        }

        [Fact]
        public void ShouldNotThrowArgumentExceptionIfGivenConditionIsFalse()
        {
            // Arrange
            bool TestProp = true;

            // Act
            Action action = () => Guard.ArgumentCondition(() => TestProp, b => b == true);

            // Assert
            action.Should().NotThrow();
        }
    }
}