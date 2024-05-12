using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1334_Find_the_City_With_the_Smallest_Number_of_Neighbors_at_a_Threshold_Distance;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindTheCity(testCase.N, testCase.Edges, testCase.DistanceThreshold), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int DistanceThreshold { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
