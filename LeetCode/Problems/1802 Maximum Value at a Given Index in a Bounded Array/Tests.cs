using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1802_Maximum_Value_at_a_Given_Index_in_a_Bounded_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxValue(testCase.N, testCase.Index, testCase.MaxSum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Index { get; [UsedImplicitly] init; }
        public int MaxSum { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
