using Xunit;

namespace ExamplesXUnitTests.Tests
{
    public class NamesTests : IClassFixture<NamesFixture>
    {
        private readonly NamesFixture _namesFixture;

        public NamesTests(NamesFixture namesFixture)
        {
            _namesFixture = namesFixture;
        }

        [Fact]
        public void MakeFullName_GivenName_ReturnString()
        {
            var result = _namesFixture._names.MakeFullName("Jefte", "Goes");

            Assert.Equal("Jefte Goes", result);
            Assert.Equal("jefte goes", result, true);
            Assert.Contains("jefte", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.StartsWith("Jefte", result);
            Assert.EndsWith("goes", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }

        [Fact]
        public void NickName_MustBeNull()
        {
            Assert.Null(_namesFixture._names.NickName);

            _namesFixture._names.NickName = "Baba Yaga";

            Assert.NotNull(_namesFixture._names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var result = _namesFixture._names.MakeFullName("Jefte", "Goes");
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}