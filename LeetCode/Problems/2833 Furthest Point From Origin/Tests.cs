using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2833_Furthest_Point_From_Origin;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FurthestDistanceFromOrigin(testCase.Moves), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Moves { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
