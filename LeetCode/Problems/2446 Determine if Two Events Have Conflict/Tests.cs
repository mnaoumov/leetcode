using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2446_Determine_if_Two_Events_Have_Conflict;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HaveConflict(testCase.Event1, testCase.Event2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Event1 { get; [UsedImplicitly] init; } = null!;
        public string[] Event2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
