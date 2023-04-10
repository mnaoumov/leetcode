using JetBrains.Annotations;

namespace LeetCode._1894_Find_the_Student_that_Will_Replace_the_Chalk;

/// <summary>
/// https://leetcode.com/submissions/detail/930980564/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        var n = chalk.Length;
        var sums = new long[n];

        for (var i = 0; i < n; i++)
        {
            sums[i] = (i > 0 ? sums[i - 1] : 0) + chalk[i];
        }

        k = (int) (k % sums[n - 1]);

        var index = Array.BinarySearch(sums, k);

        if (index < 0)
        {
            index = ~index;
        }

        return index;
    }
}
