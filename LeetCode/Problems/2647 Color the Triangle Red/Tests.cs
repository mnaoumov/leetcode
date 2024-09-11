using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2647_Color_the_Triangle_Red;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var actual = solution.ColorRed(testCase.N);
        Assert.That(actual.Length, Is.EqualTo(testCase.Output.Length));

        var triangles = new bool[testCase.N][];

        for (var i = 1; i <= testCase.N; i++)
        {
            triangles[i - 1] = new bool[2 * i - 1];
        }

        foreach (var cell in actual)
        {
            triangles[cell[0] - 1][cell[1] - 1] = true;
        }

        while (true)
        {
            var hasChanges = false;
            var hasUnmarked = false;

            for (var i = 1; i <= testCase.N; i++)
            {
                for (var j = 1; j <= 2 * i - 1; j++)
                {
                    if (triangles[i - 1][j - 1])
                    {
                        continue;
                    }

                    var neighbors = new (int row, int column)[] { (i, j - 1), (i, j + 1), j % 2 == 0 ? (i - 1, j - 1) : (i + 1, j + 1) };
                    var count = neighbors.Count(triangle =>
                        triangle is { row: >= 1, column: >= 1 } && triangle.row <= testCase.N &&
                        triangle.column <= 2 * triangle.row - 1 && triangles[triangle.row - 1][triangle.column - 1]);

                    if (count >= 2)
                    {
                        hasChanges = true;
                        triangles[i - 1][j - 1] = true;
                    }
                    else
                    {
                        hasUnmarked = true;
                    }
                }
            }

            if (hasChanges)
            {
                continue;
            }

            Assert.That(hasUnmarked, Is.False);
            return;
        }
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
