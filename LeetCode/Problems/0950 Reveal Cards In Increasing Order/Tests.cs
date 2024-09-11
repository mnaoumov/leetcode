using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0950_Reveal_Cards_In_Increasing_Order;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.DeckRevealedIncreasing(testCase.Deck), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Deck { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
