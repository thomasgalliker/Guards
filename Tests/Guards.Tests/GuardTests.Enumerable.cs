using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentNotNullOrEmptyThrowsIfEnumerableIsEmpty()
        {
            // Arrange
            string argumentName = "list";
            var list = new List<string>();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(list, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsIfEnumerableIsEmptyWithExpression()
        {
            // Arrange
            string argumentName = "list";
            var list = new List<string>();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(() => list));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().NotBeNullOrEmpty();
        }
    }
}