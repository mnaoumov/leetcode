using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2769_Find_the_Maximum_Achievable_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TheMaximumAchievableX(testCase.Num, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public int T { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
