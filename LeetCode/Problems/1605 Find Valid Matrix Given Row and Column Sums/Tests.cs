using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._1605_Find_Valid_Matrix_Given_Row_and_Column_Sums;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.RestoreMatrix(testCase.RowSum, testCase.ColSum);
        var m = testCase.RowSum.Length;
        var n = testCase.ColSum.Length;
        Assert.That(ans.Length, Is.EqualTo(m));

        for (var i = 0; i < m; i++)
        {
            Assert.That(ans[i].Length, Is.EqualTo(n));
            var rowSum = ans[i].Sum();
            Assert.That(rowSum, Is.EqualTo(testCase.RowSum[i]));
        }

        for (var j = 0; j < n; j++)
        {
            var colSum = Enumerable.Range(0, m).Select(i => ans[i][j]).Sum();
            Assert.That(colSum, Is.EqualTo(testCase.ColSum[j]));
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] RowSum { get; [UsedImplicitly] init; } = null!;
        public int[] ColSum { get; [UsedImplicitly] init; } = null!;
    }
}
