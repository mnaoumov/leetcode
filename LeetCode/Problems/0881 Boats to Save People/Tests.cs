using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0881_Boats_to_Save_People;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumRescueBoats(testCase.People, testCase.Limit), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] People { get; [UsedImplicitly] init; } = null!;
        public int Limit { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
