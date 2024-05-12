using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2359_Find_Closest_Node_to_Given_Two_Nodes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ClosestMeetingNode(testCase.Edges, testCase.Node1, testCase.Node2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Edges { get; [UsedImplicitly] init; } = null!;
        public int Node1 { get; [UsedImplicitly] init; }
        public int Node2 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
