using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0171_Excel_Sheet_Column_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TitleToNumber(testCase.ColumnTitle), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string ColumnTitle { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
