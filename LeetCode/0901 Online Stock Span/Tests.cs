using JetBrains.Annotations;

namespace LeetCode._0901_Online_Stock_Span;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create();
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase
    {
        public Action<IStockSpanner> Test { get; [UsedImplicitly] init; } = null!;
    }
}