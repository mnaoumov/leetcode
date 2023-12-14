using JetBrains.Annotations;

namespace LeetCode._2961_Double_Modular_Exponentiation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetGoodIndices(testCase.Variables, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Variables { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
