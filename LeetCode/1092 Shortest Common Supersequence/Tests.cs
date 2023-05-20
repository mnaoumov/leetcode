using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1092_Shortest_Common_Supersequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.ShortestCommonSupersequence(testCase.Str1, testCase.Str2);
        Assert.That(ans.Length, Is.EqualTo(testCase.Output.Length));

        var index1 = 0;
        var index2 = 0;

        foreach (var letter in ans)
        {
            if (index1 < testCase.Str1.Length && letter == testCase.Str1[index1])
            {
                index1++;
            }

            if (index2 < testCase.Str2.Length && letter == testCase.Str2[index2])
            {
                index2++;
            }
        }

        Assert.That(index1, Is.EqualTo(testCase.Str1.Length));
        Assert.That(index2, Is.EqualTo(testCase.Str2.Length));
    }

    public class TestCase : TestCaseBase
    {
        public string Str1 { get; [UsedImplicitly] init; } = null!;
        public string Str2 { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
