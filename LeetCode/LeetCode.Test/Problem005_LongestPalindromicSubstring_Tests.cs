using LeetCode.Problem005_LongestPalindromicSubstring;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(BruteForce))]
    public class Problem005_LongestPalindromicSubstring_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase("babad", ExpectedResult = "bab")]
        [TestCase("cbbd", ExpectedResult = "bb")]
        public string Test(string s)
        {
            return new TSolution().LongestPalindrome(s);
        }
    }
}