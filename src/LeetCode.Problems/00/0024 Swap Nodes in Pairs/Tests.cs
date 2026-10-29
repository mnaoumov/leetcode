namespace LeetCode.Problems._0024_Swap_Nodes_in_Pairs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: solution.SwapPairs,
            valuesBefore: testCase.ValuesBefore,
            valuesAfter: testCase.ValuesAfter);
    }

    public class TestCase : TestCaseBase
    {
        public int[] ValuesBefore { get; [UsedImplicitly] init; } = null!;
        public int[] ValuesAfter { get; [UsedImplicitly] init; } = null!;
    }
}
