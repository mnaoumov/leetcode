namespace LeetCode.Problems._3833_Count_Dominant_Indices;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-488/problems/count-dominant-indices/submissions/1911895855/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DominantIndices(int[] nums)
    {
        var n = nums.Length;
        var sum = nums[^1];
        var ans = 0;

        for (var i = n - 2; i >= 0; i--)
        {
            var avg = sum / (n - i - 1);

            if (nums[i] > avg)
            {
                ans++;
            }

            sum += nums[i];
        }

        return ans;
    }
}
