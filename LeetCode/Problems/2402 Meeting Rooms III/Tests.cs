using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.Helpers;

namespace LeetCode.Problems._2402_Meeting_Rooms_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MostBooked(testCase.N, ArrayHelper.DeepCopy(testCase.Meetings)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Meetings { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
