using NUnit.Framework;

namespace String.Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void passing_in_no_numbers_should_equal_zero()
        {
            var input = string.Empty;

            var result = new Calculator().Add(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void passing_in_null_should_equal_zero()
        {
            var input = string.Empty;

            var result = new Calculator().Add(input);

            Assert.AreEqual(0, result);
        }
    }
}