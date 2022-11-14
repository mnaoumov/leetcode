using JetBrains.Annotations;

namespace LeetCode._0295_Find_Median_from_Data_Stream;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create();
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public Action<IMedianFinder> Test { get; [UsedImplicitly] init; } = null!;
    }
}