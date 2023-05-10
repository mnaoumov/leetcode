using JetBrains.Annotations;

namespace LeetCode._0281_Zigzag_Iterator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var iterator = solution.Create(testCase.V1, testCase.V2);

        var list = new List<int>();

        while (iterator.HasNext())
        {
            list.Add(iterator.Next());
        }

        AssertCollectionEqualWithDetails(list, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] V1 { get; [UsedImplicitly] init; } = null!;
        public int[] V2 { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
