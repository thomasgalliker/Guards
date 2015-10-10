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
            Assert.Equal("testProp", ex.ParamName);
        }

        [Fact]
        public void ArgumentNullThrowsIfArgumentIsNotNull()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNull("value", argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullThrowsIfNullableArgumentIsNull()
        {
            // Arrange
            bool? testProp = null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(() => testProp));

            // Assert
            Assert.Equal("testProp", ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullThrowsIfArgumentIsNull()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((string)null, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullNotThrowsIfArgumentNameIsNullOrEmpty()
        {
            // Act
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, (string)null));
            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, string.Empty));

            // Assert
            Assert.Null(ex1.ParamName);
            Assert.Equal(string.Empty, ex2.ParamName);
        }

        [Fact]
        public void ArgumentMustNotExceedThrowsArgumentExceptionTooLow()
        {
            // Arrange
            const int MaxLength = 3;
            string inputTest = "1234";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentMustNotExceed(() => inputTest, MaxLength));

            // Assert
            Assert.Equal("inputTest", ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullThrowsWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsIfArgumentIsNull()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(null, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().NotBeNullOrEmpty();
        }


        [Fact]
        public void ArgumentNotNullOrEmptyThrowsIfArgumentIsEmpty()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(string.Empty, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsArgumentNullExceptionIfArgumentNameIsNull()
        {
            // Act
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(null, (string)null));
            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(null, string.Empty));

            // Assert
            ex1.ParamName.Should().BeNull();
            ex1.Message.Should().NotBeNullOrEmpty();

            ex2.ParamName.Should().BeEmpty();
            ex2.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsArgumentExceptionIfArgumentNameIsEmpty()
        {
            // Act
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(string.Empty, (string)null));
            var ex2 = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(string.Empty, string.Empty));

            // Assert
            ex1.ParamName.Should().BeNull();
            ex1.Message.Should().NotBeNullOrEmpty();

            ex2.ParamName.Should().BeEmpty();
            ex2.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsArgumentNullExceptionWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(null, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsArgumentExceptionWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(string.Empty, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsArgumentNullExceptionWithExpression()
        {
            // Arrange
            string argument = null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(() => argument));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentNotNullOrEmptyThrowsArgumentExceptionWithExpression()
        {
            // Arrange
            string argument = string.Empty;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(() => argument));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().NotBeNullOrEmpty();
        }
    }
}