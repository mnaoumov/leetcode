using LeetCode.Problem007_ReverseInteger;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(Solution))]
    public class Problem007_ReverseInteger_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase(123, ExpectedResult = 321)]
        [TestCase(-123, ExpectedResult = -321)]
        [TestCase(120, ExpectedResult = 21)]
        [TestCase(1111111113, ExpectedResult = 0)]
        [TestCase(int.MinValue, ExpectedResult = 0)]
        [Timeout(100)]
        public int Test(int x)
        {
            return new TSolution().Reverse(x);
        }
    }
}