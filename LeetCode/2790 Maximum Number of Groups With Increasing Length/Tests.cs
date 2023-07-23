using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2790_Maximum_Number_of_Groups_With_Increasing_Length;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxIncreasingGroups(testCase.UsageLimits), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> UsageLimits { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
