using LeetCode.Problem003_LongestSubstringWithoutRepeatingCharacters;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(BruteForce))]
    [TestFixture(typeof(MoveSlowly))]
    [TestFixture(typeof(MoveQuicker))]
    [TestFixture(typeof(ArrayBased))]
    public class Problem003_LongestSubstringWithoutRepeatingCharacters_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase("abcabcbb", ExpectedResult = 3)]
        [TestCase("bbbbb", ExpectedResult = 1)]
        [TestCase("pwwkew", ExpectedResult = 3)]
        public int Test(string s)
        {
            return new TSolution().LengthOfLongestSubstring(s);
        }
    }
}