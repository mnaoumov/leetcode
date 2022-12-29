
using JetBrains.Annotations;

namespace LeetCode._1834_Single_Threaded_CPU;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetOrder(testCase.Tasks), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Tasks { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
