namespace LeetCode.Problems._3447_Assign_Elements_to_Groups_with_Constraints;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AssignElements(testCase.Groups, testCase.Elements), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Groups { get; [UsedImplicitly] init; } = null!;
        public int[] Elements { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
