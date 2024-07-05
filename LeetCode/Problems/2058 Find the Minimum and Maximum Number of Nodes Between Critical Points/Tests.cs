using JetBrains.Annotations;

namespace LeetCode.Problems._2058_Find_the_Minimum_and_Maximum_Number_of_Nodes_Between_Critical_Points;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.NodesBetweenCriticalPoints(ListNode.CreateOrNull(testCase.Head)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
