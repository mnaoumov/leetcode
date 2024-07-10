using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2902_Count_of_Sub_Multisets_With_Bounded_Sum;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSubMultisets(testCase.Nums, testCase.L, testCase.R), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Nums { get; [UsedImplicitly] init; } = null!;
        public int L { get; [UsedImplicitly] init; }
        public int R { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
