
using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._1901_Find_a_Peak_Element_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var cell = solution.FindPeakGrid(testCase.Mat);
        var row = cell[0];
        var column = cell[1];
        var max = SafeGet(row, column);

        Assert.That(max, Is.GreaterThan(SafeGet(row + 1, column)));
        Assert.That(max, Is.GreaterThan(SafeGet(row - 1, column)));
        Assert.That(max, Is.GreaterThan(SafeGet(row, column + 1)));
        Assert.That(max, Is.GreaterThan(SafeGet(row, column - 1)));
        return;

        int SafeGet(int row2, int column2) =>
            row2 < 0 || row2 >= testCase.Mat.Length || column2 < 0 || column2 >= testCase.Mat[0].Length
                ? -1
                : testCase.Mat[row2][column2];
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Mat { get; [UsedImplicitly] init; } = null!;
    }
}
