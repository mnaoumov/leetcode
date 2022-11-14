using JetBrains.Annotations;

namespace LeetCode._0341_Flatten_Nested_List_Iterator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var i = solution.Create(testCase.NestedList);

        var list = new List<int>();

        while (i.HasNext())
        {
            list.Add(i.Next());
        }

        AssertCollectionEqualWithDetails(list, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public NestedInteger[] NestedList { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}