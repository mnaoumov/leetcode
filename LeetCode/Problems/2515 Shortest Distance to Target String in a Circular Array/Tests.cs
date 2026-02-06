namespace LeetCode.Problems._2515_Shortest_Distance_to_Target_String_in_a_Circular_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ClosetTarget(testCase.Words, testCase.Target, testCase.StartIndex), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public string Target { get; [UsedImplicitly] init; } = null!;
        public int StartIndex { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
