using Xunit;

namespace Calculations.Tests
{
    public class NamesTest
    {
        [Fact]
        public void MakeFullName_GivenName_ReturnString()
        {
            var names = new Names();
            var result = names.MakeFullName("Jefte", "Goes");

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
            var names = new Names();

            Assert.Null(names.NickName);

            names.NickName = "Baba Yaga";

            Assert.NotNull(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Jefte", "Goes");
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}