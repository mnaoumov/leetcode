namespace LeetCode._025_Reverse_Nodes_in_k_Group;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: list => solution.ReverseKGroup(list, testCase.K),
            valuesBefore: testCase.ValuesBefore,
            valuesAfter: testCase.ValuesAfter);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int K { get; private init; }
        public int[] ValuesBefore { get; private init; } = null!;
        public int[] ValuesAfter { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    K = 2,
                    ValuesBefore = new[] { 1, 2, 3, 4, 5 },
                    ValuesAfter = new[] { 2, 1, 4, 3, 5 },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    K = 3,
                    ValuesBefore = new[] { 1, 2, 3, 4, 5 },
                    ValuesAfter = new[] { 3, 2, 1, 4, 5 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
