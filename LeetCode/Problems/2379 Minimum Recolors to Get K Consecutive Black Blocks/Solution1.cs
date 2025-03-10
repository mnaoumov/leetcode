namespace LeetCode.Problems._2379_Minimum_Recolors_to_Get_K_Consecutive_Black_Blocks;

/// <summary>
/// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/submissions/1566548081/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumRecolors(string blocks, int k)
    {
        const int black = 'B';

        var blackCount = 0;

        for (var i = 0; i < k; i++)
        {
            if (blocks[i] == black)
            {
                blackCount++;
            }
        }

        var ans = k - blackCount;

        for (var i = k; i < blocks.Length; i++)
        {
            if (blocks[i - k] == black)
            {
                blackCount--;
            }

            if (blocks[i] == black)
            {
                blackCount++;
            }

            ans = Math.Min(ans, k - blackCount);
        }

        return ans;
    }
}
