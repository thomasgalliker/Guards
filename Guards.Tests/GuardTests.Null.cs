using System;

using FluentAssertions;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void ArgumentNullThrowsIfNullableArgumentIsNotNull()
        {
            // Arrange
            bool? testProp = false;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNull(() => testProp));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("testProp");
            ex.Message.Should().Contain("Argument must be null.");
        }

        [Fact]
        public void ArgumentNullThrowsIfArgumentIsNotNull()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNull("value", argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Contain("Argument must be null.");
        }

        [Fact]
        public void ArgumentNotNullThrowsIfNullableArgumentIsNull()
        {
            // Arrange
            bool? testProp = null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(() => testProp));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("testProp");
            ex.Message.Should().Contain("Argument must not be null.");
        }

        [Fact]
        public void ArgumentNotNullThrowsIfArgumentIsNull()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((string)null, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Contain("Argument must not be null.");
        }

        [Fact]
        public void ArgumentNotNullNotThrowsIfArgumentNameIsNullOrEmpty()
        {
            // Act
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, (string)null));
            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, string.Empty));

            // Assert
            ex1.ParamName.Should().BeNull();
            ex1.Message.Should().Contain("Argument must not be null.");

            ex2.ParamName.Should().BeEmpty();
            ex2.Message.Should().Contain("Argument must not be null.");
        }

        [Fact]
        public void ArgumentNotNullThrowsWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Contain("Argument must not be null.");
        }
    }
}