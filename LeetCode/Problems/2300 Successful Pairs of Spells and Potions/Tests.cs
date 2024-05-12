
using JetBrains.Annotations;

namespace LeetCode._2300_Successful_Pairs_of_Spells_and_Potions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SuccessfulPairs(testCase.Spells, testCase.Potions, testCase.Success), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Spells { get; [UsedImplicitly] init; } = null!;
        public int[] Potions { get; [UsedImplicitly] init; } = null!;
        public long Success { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
