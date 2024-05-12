using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2214_Minimum_Health_to_Beat_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumHealth(testCase.Damage, testCase.Armor), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Damage { get; [UsedImplicitly] init; } = null!;
        public int Armor { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
