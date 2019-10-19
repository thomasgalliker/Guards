using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentNotNullOrEmpty_DoesNotThrowIfEnumerableContainsItems()
        {
            // Arrange
            var enumerable = new List<string> { "item1", "item2" };
            string argumentName = nameof(enumerable);

            // Act
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Action action = () => Guard.ArgumentNotNullOrEmpty(enumerable, argumentName);

                // Assert
                action.Should().NotThrow<ArgumentException>();
            }
        }

        [Fact]
        public void ArgumentNotNullOrEmpty_ThrowsIfEnumerableIsEmpty()
        {
            // Arrange
            var enumerable = new List<string>();
            string argumentName = nameof(enumerable);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(enumerable, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Be("Argument must not be empty.\r\nParameter name: enumerable");
        }

        [Fact]
        public void ArgumentNotNullOrEmpty_ThrowsIfEnumerableIsEmptyWithExpression()
        {
            // Arrange
            var enumerable = new List<string>();
            string argumentName = nameof(enumerable);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(() => enumerable));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Be("Argument must not be empty.\r\nParameter name: enumerable");
        }
    }
}