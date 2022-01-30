using Xunit;
using Xunit.Abstractions;

namespace ExamplesXUnitTests.Tests
{
    public class CalculationsFixture
    {
        public Calculations Calculations => new Calculations();
    }

    public class CalculationsTests : IClassFixture<CalculationsFixture>, IDisposable
    {
        private readonly CalculationsFixture _calculationsFixture;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MemoryStream _memoryStream;

        public CalculationsTests(ITestOutputHelper testOutputHelper,
                                 CalculationsFixture calculationsFixture)
        {
            _memoryStream = new MemoryStream();
            _testOutputHelper = testOutputHelper;
            _calculationsFixture = calculationsFixture;

            _testOutputHelper.WriteLine("Constructor");
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var calculations = _calculationsFixture.Calculations;
            var result = calculations.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calculations = _calculationsFixture.Calculations;
            var result = calculations.AddDouble(1.2, 3.5);

            Assert.Equal(4.7, result);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboIsNotZero()
        {
            _testOutputHelper.WriteLine("CheckFiboIsNotZero");
            var calculations = _calculationsFixture.Calculations;

            Assert.All(calculations.FiboNumbers, n => Assert.NotEqual(0, n));
            Assert.DoesNotContain(0, calculations.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Check13Exists()
        {
            _testOutputHelper.WriteLine("Check13Exists");
            var calculations = _calculationsFixture.Calculations;
            Assert.Contains(13, calculations.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboIsNotFour()
        {
            _testOutputHelper.WriteLine("CheckFiboIsNotFour");
            var calculations = _calculationsFixture.Calculations;
            Assert.DoesNotContain(4, calculations.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboNumbers()
        {
            _testOutputHelper.WriteLine("CheckFiboNumbers. Test Starting at {0}", DateTime.Now);

            var calculations = _calculationsFixture.Calculations;
            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };

            _testOutputHelper.WriteLine("Asserting...");
            Assert.Equal(expectedCollection, calculations.FiboNumbers);
            _testOutputHelper.WriteLine("End");
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var calculations = _calculationsFixture.Calculations;
            Assert.Equal(expected, calculations.IsOdd(value));
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEvenSharedData(int value, bool expected)
        {
            var calculations = _calculationsFixture.Calculations;
            Assert.Equal(expected, calculations.IsOdd(value));
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEvenSharedDataExternal(int value, bool expected)
        {
            var calculations = _calculationsFixture.Calculations;
            Assert.Equal(expected, calculations.IsOdd(value));
        }

        [Theory]
        [IsOddOrEvenData]
        public void IsOdd_TestOddAndEvenSharedDataAttribute(int value, bool expected)
        {
            var calculations = _calculationsFixture.Calculations;
            Assert.Equal(expected, calculations.IsOdd(value));
        }

        public void Dispose()
        {
            _memoryStream.Close();
        }
    }
}