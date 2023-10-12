using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1095_Find_in_Mountain_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindInMountainArray(testCase.Target, new MountainArray(testCase.Array)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Array { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
