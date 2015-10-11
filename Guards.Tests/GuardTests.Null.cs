using System;



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
        public void ArgumentNotNullThrowsWithProvidedArgumentName()
        {
            // Arrange
            string argumentName = "argument";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull((object)null, argumentName));

            // Assert
            Assert.Equal(argumentName, ex.ParamName);
        }
    }
}