using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2557_Maximum_Number_of_Integers_to_Choose_From_a_Range_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxCount(testCase.Banned, testCase.N, testCase.MaxSum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Banned { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public long MaxSum { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
