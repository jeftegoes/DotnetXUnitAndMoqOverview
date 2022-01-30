using Xunit;

namespace ExamplesXUnitTests.Tests
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerDetailsTests(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            var customer = _customerFixture.Customer;
            Assert.Equal("Jefté Goes", customer.GetFullName("Jefté", "Goes"));
        }
    }
}