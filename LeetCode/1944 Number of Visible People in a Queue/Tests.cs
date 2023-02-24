
using JetBrains.Annotations;

namespace LeetCode._1944_Number_of_Visible_People_in_a_Queue;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CanSeePersonsCount(testCase.Heights), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Heights { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
