namespace LeetCode.Problems._0364_Nested_List_Weight_Sum_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DepthSumInverse(NestedIntegerImpl.Create(testCase.NestedList)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public object[] NestedList { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
