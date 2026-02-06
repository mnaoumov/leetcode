namespace LeetCode.Problems._2737_Find_the_Closest_Marked_Node;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumDistance(testCase.N, testCase.Edges, testCase.S, testCase.Marked), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public IList<IList<int>> Edges { get; [UsedImplicitly] init; } = null!;
        public int S { get; [UsedImplicitly] init; }
        public int[] Marked { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
