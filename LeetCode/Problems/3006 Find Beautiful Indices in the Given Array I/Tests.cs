using JetBrains.Annotations;

namespace LeetCode._3006_Find_Beautiful_Indices_in_the_Given_Array_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.BeautifulIndices(testCase.S, testCase.A, testCase.B, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string A { get; [UsedImplicitly] init; } = null!;
        public string B { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
