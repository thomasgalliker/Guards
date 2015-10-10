using System;


using Guards.Tests.Stubs;

using Xunit;

namespace Guards.Tests
{
    public partial class GuardTests
    {
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
    }
}