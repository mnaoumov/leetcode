using LeetCode.Problem008_StringToIntegerAtoi;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(Solution))]
    public class Problem008_StringToIntegerAtoi_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase("1234", ExpectedResult = 1234)]
        [TestCase("+1234", ExpectedResult = 1234)]
        [TestCase("-1234", ExpectedResult = -1234)]
        [TestCase("   0000123", ExpectedResult = 123)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase("     ", ExpectedResult = 0)]
        [TestCase("     /", ExpectedResult = 0)]
        [TestCase("1234/@abc", ExpectedResult = 1234)]
        [TestCase("2147483648", ExpectedResult = 2147483647, Description = "Above max value")]
        [TestCase("-2147483649", ExpectedResult = -2147483648, Description = "Below min value")]
        [Timeout(100)]
        public int Test(string str)
        {
            return new TSolution().MyAtoi(str);
        }
    }
}