using JetBrains.Annotations;

namespace LeetCode.Problems._0241_Different_Ways_to_Add_Parentheses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.DiffWaysToCompute(testCase.Expression), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string Expression { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
