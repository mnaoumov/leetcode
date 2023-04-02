
using JetBrains.Annotations;

namespace LeetCode._2612_Minimum_Reverse_Operations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinReverseOperations(testCase.N, testCase.P, testCase.Banned, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int P { get; [UsedImplicitly] init; }
        public int[] Banned { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
