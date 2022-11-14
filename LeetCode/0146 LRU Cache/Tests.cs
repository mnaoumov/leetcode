using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create(testCase.Capacity);
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Capacity { get; [UsedImplicitly] init; }
        public Action<ILRUCache> Test { get; [UsedImplicitly] init; } = null!;
    }
}