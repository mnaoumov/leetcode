using LeetCode.Problem006_ZigZagConversion;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(Solution))]
    public class Problem006_ZigZagConversion_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase("PAYPALISHIRING", 3, ExpectedResult = "PAHNAPLSIIGYIR")]
        public string Test(string s, int numRows)
        {
            return new TSolution().Convert(s, numRows);
        }
    }
}