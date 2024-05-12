using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2478_Number_of_Beautiful_Partitions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BeautifulPartitions(testCase.S, testCase.K, testCase.MinLength), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int MinLength { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
