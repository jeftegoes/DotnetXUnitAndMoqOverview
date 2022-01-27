using Xunit;

namespace Calculations.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var calculator = new Calculator();
            var result = calculator.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calculator = new Calculator();
            var result = calculator.AddDouble(1.2, 3.5);

            Assert.Equal(4.7, result);
        }

        [Fact]
        public void FiboDoesNotIncludeZero()
        {
            var calculator = new Calculator();

            Assert.All(calculator.FiboNumbers, n => Assert.NotEqual(0, n));
            Assert.DoesNotContain(0, calculator.FiboNumbers);
        }

        [Fact]
        public void FiboIncludes13()
        {
            var calculator = new Calculator();
            Assert.Contains(13, calculator.FiboNumbers);
        }

        [Fact]
        public void FiboDoesNotInclude4()
        {
            var calculator = new Calculator();
            Assert.DoesNotContain(4, calculator.FiboNumbers);
        }

        [Fact]
        public void CheckCollection()
        {            
            var calculator = new Calculator();
            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };

            Assert.Equal(expectedCollection, calculator.FiboNumbers);
        }
    }
}