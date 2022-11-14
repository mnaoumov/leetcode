using JetBrains.Annotations;

namespace LeetCode._0981_Time_Based_Key_Value_Store;

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
        public Action<ITimeMap> Test { get; [UsedImplicitly] init; } = null!;
    }
}