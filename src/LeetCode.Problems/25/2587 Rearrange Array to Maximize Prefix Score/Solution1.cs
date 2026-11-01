namespace LeetCode.Problems._2587_Rearrange_Array_to_Maximize_Prefix_Score;

/// <seealso href="https://leetcode.com/contest/weekly-contest-336/submissions/detail/913518471/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxScore(int[] nums)
    {
        Array.Sort(nums, Comparer<int>.Create((a, b) => b.CompareTo(a)));

        var result = 0;
        var prefix = 0L;

        foreach (var num in nums)
        {
            prefix += num;

            if (prefix <= 0)
            {
                break;
            }

            result++;
        }

        return result;
    }
}
