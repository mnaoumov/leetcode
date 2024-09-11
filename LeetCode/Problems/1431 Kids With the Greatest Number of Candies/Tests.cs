
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1431_Kids_With_the_Greatest_Number_of_Candies;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.KidsWithCandies(testCase.Candies, testCase.ExtraCandies), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Candies { get; [UsedImplicitly] init; } = null!;
        public int ExtraCandies { get; [UsedImplicitly] init; }
        public IList<bool> Output { get; [UsedImplicitly] init; } = null!;
    }
}
