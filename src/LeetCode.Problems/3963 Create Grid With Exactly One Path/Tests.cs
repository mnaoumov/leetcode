namespace LeetCode.Problems._3963_Create_Grid_With_Exactly_One_Path;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var grid = solution.CreateGrid(testCase.M, testCase.N);

        var m = grid.Length;
        var n = grid[0].Length;
        const char freeCell = '.';

        Assert.That(m, Is.EqualTo(testCase.M), $"Result should have {testCase.M} rows");
        Assert.That(n, Is.EqualTo(testCase.N), $"Result should have {testCase.N} columns");

        AssertUniquePath(0, 0);

        return;

        void AssertUniquePath(int row, int column)
        {
            var cellStr = $"({row},{column})";

            var pathState = GetPathState(row, column);

            switch (pathState)
            {
                case PathState.StartIsNotFreeCell:
                    Assert.Fail($"{cellStr} has to be a free cell");
                    break;
                case PathState.StartIsNotValidCell:
                    Assert.Fail($"{cellStr} has to be a valid cell");
                    break;
                case PathState.UniquePath:
                    break;
                case PathState.NoPath:
                    Assert.Fail($"There is no path starting from {cellStr}");
                    break;
                case PathState.NonUniquePath:
                    Assert.Fail($"There are multiple paths starting from {cellStr}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pathState), pathState, null);
            }
        }

        PathState GetPathState(int row, int column)
        {
            if (row < 0 || row >= m || column < 0 || column >= n)
            {
                return PathState.StartIsNotValidCell;
            }

            if (grid[row][column] != freeCell)
            {
                return PathState.StartIsNotFreeCell;
            }

            if (row == m - 1 && column == n - 1)
            {
                return PathState.UniquePath;
            }

            var downPathState = GetPathState(row + 1, column);
            var rightPathState = GetPathState(row, column + 1);

            if (downPathState == PathState.NonUniquePath || rightPathState == PathState.NonUniquePath)
            {
                return PathState.NonUniquePath;
            }

            if (downPathState == PathState.UniquePath && rightPathState == PathState.UniquePath)
            {
                return PathState.NonUniquePath;
            }

            if (downPathState != PathState.UniquePath && rightPathState != PathState.UniquePath)
            {
                return PathState.NoPath;
            }

            return PathState.UniquePath;
        }
    }

    private enum PathState
    {
        StartIsNotFreeCell,
        StartIsNotValidCell,
        UniquePath,
        NoPath,
        NonUniquePath
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
