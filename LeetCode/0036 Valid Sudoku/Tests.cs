using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0036_Valid_Sudoku;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsValidSudoku(testCase.Board), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
