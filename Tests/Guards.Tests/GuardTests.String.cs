using System;

using FluentAssertions;


using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {


        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsIfArgumentIsNull()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(null, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Contain("Argument must not be null.");
        }


        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsIfArgumentIsEmpty()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(string.Empty, argumentName));

            // Assert
            ex.ParamName.Should().BeEquivalentTo(argumentName);
            ex.Message.Should().Contain("Argument must not be empty or whitespace.");
        }
        
      
        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentNullExceptionIfArgumentNameIsWhiteSpace()
        {
            const string whiteSpace = "    ";
            // Act
            var expected = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(null, whiteSpace));

            // Assert
            expected.ParamName.Should().Be(whiteSpace);
            expected.Message.Should().NotBeNullOrEmpty();
        }
        
        
        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentNullExceptionIfArgumentNameIsNull()
        {
            // Act
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(null, (string)null));
            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(null, string.Empty));

            // Assert
            ex1.ParamName.Should().BeNull();
            ex1.Message.Should().NotBeNullOrEmpty();

            ex2.ParamName.Should().BeEmpty();
            ex2.Message.Should().NotBeNullOrEmpty();
           }

        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentExceptionIfArgumentNameIsEmpty()
        {
            // Act
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(string.Empty, (string)null));
            var ex2 = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(string.Empty, string.Empty));

            // Assert
            ex1.ParamName.Should().BeNull();
            ex1.Message.Should().NotBeNullOrEmpty();

            ex2.ParamName.Should().BeEmpty();
            ex2.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentNullExceptionWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(null, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentExceptionWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(string.Empty, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }

        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentNullExceptionWithExpression()
        {
            // Arrange
            string argument = null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrWhiteSpace(() => argument));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("Argument must not be null.");
        }

        [Fact]
        public void ArgumentNotNullOrWhiteSpaceThrowsArgumentExceptionWithExpression()
        {
            // Arrange
            string argument = string.Empty;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrWhiteSpace(() => argument));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("Argument must not be empty or whitespace.");
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
            ex.Message.Should().Contain("Argument must not be null.");
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
            ex.Message.Should().Contain("Argument must not be empty.");
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
            ex.Message.Should().Contain("Argument must not be null.");
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
            ex.Message.Should().Contain("Argument must not be empty.");
        }

        [Fact]
        public void ArgumentHasLengthThrowsIfLengthDoesNotMatchWithExpression()
        {
            // Arrange
            string argument = "123456789";
            int expectedLength = 10;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasLength(() => argument, expectedLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("Expected string length is 10, but found 9");
        }

        [Fact]
        public void ArgumentHasLengthThrowsIfLengthDoesNotMatch()
        {
            // Arrange
            string argument = "123456789";
            int expectedLength = 10;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasLength(argument, nameof(argument), expectedLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("Expected string length is 10, but found 9.");
        }

        [Fact]
        public void ArgumentHasMaxLengthThrowsIfStringIsLongerThanExpectedWithExpression()
        {
            // Arrange
            string argument = "123456789";
            int expectedMaxLength = 3;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasMaxLength(() => argument, expectedMaxLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("String length exceeds maximum of 3 characters. Found string of length 9");
        }

        [Fact]
        public void ArgumentHasMaxLengthThrowsIfStringIsLongerThanExpected()
        {
            // Arrange
            string argument = "123456789";
            int expectedMaxLength = 3;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasMaxLength(argument, nameof(argument), expectedMaxLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("String length exceeds maximum of 3 characters. Found string of length 9");
        }

        [Fact]
        public void ArgumentHasMinLengthThrowsIfStringIsLongerThanExpected()
        {
            // Arrange
            string argument = "12";
            int expectedMinLength = 3;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasMinLength(() => argument, expectedMinLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("String must have a minimum of 3 characters. Found string of length 2.");
        }

        [Fact]
        public void ArgumentHasMinLengthThrowsIfStringIsLongerThanExpectedWithExpression()
        {
            // Arrange
            string argument = "12";
            int expectedMinLength = 3;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasMinLength(argument, nameof(argument), expectedMinLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().Contain("String must have a minimum of 3 characters. Found string of length 2.");
        }
    }
}