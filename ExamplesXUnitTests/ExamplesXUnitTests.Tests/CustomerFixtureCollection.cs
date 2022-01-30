using Xunit;

namespace ExamplesXUnitTests.Tests
{
    [CollectionDefinition("Customer")]
    public class CustomerFixtureCollection : ICollectionFixture<CustomerFixture>
    {
        
    }
}