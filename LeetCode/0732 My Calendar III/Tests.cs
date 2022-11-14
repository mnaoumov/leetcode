using JetBrains.Annotations;

namespace LeetCode._0732_My_Calendar_III;

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
        public Action<IMyCalendarThree> Test { get; [UsedImplicitly] init; } = null!;
    }
}