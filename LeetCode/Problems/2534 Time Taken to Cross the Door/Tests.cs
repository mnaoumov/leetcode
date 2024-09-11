
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2534_Time_Taken_to_Cross_the_Door;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.TimeTaken(testCase.Arrival, testCase.State), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arrival { get; [UsedImplicitly] init; } = null!;
        public int[] State { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
