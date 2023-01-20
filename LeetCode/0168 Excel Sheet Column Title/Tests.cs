using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0168_Excel_Sheet_Column_Title;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ConvertToTitle(testCase.ColumnNumber), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int ColumnNumber { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
