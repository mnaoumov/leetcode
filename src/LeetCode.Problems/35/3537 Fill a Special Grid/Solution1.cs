namespace LeetCode.Problems._3537_Fill_a_Special_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-448/problems/fill-a-special-grid/submissions/1624868010/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public int[][] SpecialGrid(int N)
    {
        var size = 1 << N;

        var ans = Enumerable.Range(0, size)
            .Select(_ => new int[size])
            .ToArray();
        Init(0, 0, size, 0);

        return ans;

        void Init(int top, int left, int length, int minNumber)
        {
            if (length == 1)
            {
                ans[top][left] = minNumber;
                return;
            }

            var step = length * length / 4;
            Init(top, left + length / 2, length / 2, minNumber);
            Init(top + length/2, left + length / 2, length / 2, minNumber + step);
            Init(top + length/2, left, length / 2, minNumber + 2 * step);
            // ReSharper disable once TailRecursiveCall
            Init(top, left, length / 2, minNumber + 3 * step);
        }
    }
}
