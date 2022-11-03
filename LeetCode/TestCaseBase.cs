using System.Collections;

namespace LeetCode;

public abstract class TestCaseBase
{
    public string? TestCaseName { get; protected init; }
    public int TimeoutInMilliseconds { get; } = 200;
}

public abstract class TestCaseBase<TTestCase> : TestCaseBase, ITestCase where TTestCase : TestCaseBase<TTestCase>
{
    public abstract IEnumerable<TTestCase> TestCases { get; }
    IEnumerable<TestCaseBase> ITestCase.TestCases => TestCases;
}
