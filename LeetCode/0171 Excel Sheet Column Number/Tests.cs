using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0171_Excel_Sheet_Column_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TitleToNumber(testCase.ColumnTitle), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string ColumnTitle { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}