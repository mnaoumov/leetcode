namespace LeetCode._0024_Swap_Nodes_in_Pairs;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: solution.SwapPairs,
            valuesBefore: testCase.ValuesBefore,
            valuesAfter: testCase.ValuesAfter);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] ValuesBefore { get; private init; } = null!;
        public int[] ValuesAfter { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    ValuesBefore = new[] { 1, 2, 3, 4 },
                    ValuesAfter = new[] { 2, 1, 4, 3 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    ValuesBefore = Array.Empty<int>(),
                    ValuesAfter = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    ValuesBefore = new[] { 1 },
                    ValuesAfter = new[] { 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
