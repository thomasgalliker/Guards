using System;

using FluentAssertions;

using Guards.Tests.Stubs;

using Xunit;

namespace Guards.Tests
{
    public class GuardTests
    {
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

        [Fact]
        public void ArgumentMustBeInterfaceThrowsIfArgumentIsNotAnInterface()
        {
            // Arrange
            Type classType = typeof(DemoClass);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentMustBeInterface(classType));

            // Assert
            Assert.Equal(classType.Name, ex.ParamName);
        }

        [Fact]
        public void ArgumentMustNotBeInterfaceThrowsIfArgumentIsAnInterface()
        {
            // Arrange
            Type interfaceType = typeof(IDemoInterface);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentMustNotBeInterface(interfaceType));

            // Assert
            Assert.Equal(interfaceType.Name, ex.ParamName);
        }

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