﻿using System;

using FluentAssertions;


using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
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
        public void ArgumentHasLengthThrowsIfLengthDoesNotMatch()
        {
            // Arrange
            string argument = "123456789";
            int expectedLength = 10;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasLength(() => argument, expectedLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentHasMaxLengthThrowsIfStringIsLongerThanExcepected()
        {
            // Arrange
            string argument = "123456789";
            int expectedMaxLength = 3;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasMaxLength(() => argument, expectedMaxLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ArgumentHasMinLengthThrowsIfStringIsLongerThanExcepected()
        {
            // Arrange
            string argument = "12";
            int expectedMinLength = 3;

            // Act
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentHasMinLength(() => argument, expectedMinLength));

            // Assert
            ex.ParamName.Should().BeEquivalentTo("argument");
            ex.Message.Should().NotBeNullOrEmpty();
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

    }
}