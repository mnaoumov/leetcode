namespace LeetCode.Problems._3468_Find_the_Number_of_Copy_Arrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-151/problems/find-the-number-of-copy-arrays/submissions/1559246308/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountArrays(int[] original, int[][] bounds)
    {
        var minOffset = int.MinValue;
        var maxOffset = int.MaxValue;

        var n = original.Length;

        for (var i = 0; i < n; i++)
        {
            var num = original[i];
            minOffset = Math.Max(minOffset, bounds[i][0] - num);
            maxOffset = Math.Min(maxOffset, bounds[i][1] - num);

            if (minOffset > maxOffset)
            {
                return 0;
            }
        }

        return maxOffset - minOffset + 1;
    }
}
