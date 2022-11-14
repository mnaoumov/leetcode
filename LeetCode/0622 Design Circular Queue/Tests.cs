using JetBrains.Annotations;

namespace LeetCode._0622_Design_Circular_Queue;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create(testCase.K);
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int K { get; [UsedImplicitly] init; }
        public Action<IMyCircularQueue> Test { get; [UsedImplicitly] init; } = null!;
    }
}