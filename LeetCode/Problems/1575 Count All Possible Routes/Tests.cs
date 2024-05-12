using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1575_Count_All_Possible_Routes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountRoutes(testCase.Locations, testCase.Start, testCase.Finish, testCase.Fuel), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Locations { get; [UsedImplicitly] init; } = null!;
        public int Start { get; [UsedImplicitly] init; }
        public int Finish { get; [UsedImplicitly] init; }
        public int Fuel { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
