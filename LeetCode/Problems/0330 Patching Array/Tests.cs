using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0330_Patching_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinPatches(testCase.Nums, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
