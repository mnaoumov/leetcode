using JetBrains.Annotations;

namespace LeetCode._0025_Reverse_Nodes_in_k_Group;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: list => solution.ReverseKGroup(list!, testCase.K),
            valuesBefore: testCase.ValuesBefore,
            valuesAfter: testCase.ValuesAfter);
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int[] ValuesBefore { get; [UsedImplicitly] init; } = null!;
        public int[] ValuesAfter { get; [UsedImplicitly] init; } = null!;
    }
}