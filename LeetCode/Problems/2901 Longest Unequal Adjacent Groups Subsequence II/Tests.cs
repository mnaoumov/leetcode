using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2901_Longest_Unequal_Adjacent_Groups_Subsequence_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.GetWordsInLongestSubsequence(testCase.N, testCase.Words, testCase.Groups);

        Assert.That(ans.Count, Is.EqualTo(testCase.Output.Count));

        var indices = ans.Select(word => Array.IndexOf(testCase.Words, word)).ToArray();

        for (var i = 0; i < indices.Length; i++)
        {
            var index = indices[i];
            Assert.That(index, Is.Not.EqualTo(-1));

            if (i == 0)
            {
                continue;
            }

            var previousIndex = indices[i - 1];
            Assert.That(index, Is.GreaterThan(previousIndex));
            Assert.That(testCase.Groups[index], Is.Not.EqualTo(testCase.Groups[previousIndex]));
            var word = testCase.Words[i];
            var previousWord = testCase.Words[i - 1];
            Assert.That(word.Length, Is.EqualTo(previousWord.Length));

            var hammingDistance = word.Where((letter, letterIndex) => letter != previousWord[letterIndex]).Count();
            Assert.That(hammingDistance, Is.EqualTo(1));
        }
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int[] Groups { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
