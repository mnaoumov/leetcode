using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1562_Find_Latest_Group_of_Size_M;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindLatestStep(testCase.Arr, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
