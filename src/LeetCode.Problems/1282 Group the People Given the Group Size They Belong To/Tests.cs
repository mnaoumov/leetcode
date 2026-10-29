namespace LeetCode.Problems._1282_Group_the_People_Given_the_Group_Size_They_Belong_To;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.GroupThePeople(testCase.GroupSizes), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] GroupSizes { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
