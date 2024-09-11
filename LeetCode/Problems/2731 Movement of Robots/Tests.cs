using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2731_Movement_of_Robots;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SumDistance(testCase.Nums, testCase.S, testCase.D), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public string S { get; [UsedImplicitly] init; } = null!;
        public int D { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
