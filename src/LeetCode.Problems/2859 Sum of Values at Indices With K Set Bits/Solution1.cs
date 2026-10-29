namespace LeetCode.Problems._2859_Sum_of_Values_at_Indices_With_K_Set_Bits;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-363/submissions/detail/1051399238/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumIndicesWithKSetBits(IList<int> nums, int k)
    {
        var n = nums.Count;

        var ans = 0;
        for (var i = 0; i < n; i++)
        {
            if (BitsCount(i) == k)
            {
                ans += nums[i];
            }
        }

        return ans;
    }

    private static int BitsCount(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            if ((num & 1) == 1)
            {
                ans++;
            }

            num >>= 1;
        }
        return ans;
    }
}
