namespace LeetCode.Problems._0755_Pour_Water;

/// <summary>
/// https://leetcode.com/problems/pour-water/submissions/1972154428/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] PourWater(int[] heights, int volume, int k)
    {
        var ans = heights.ToArray();

        var n = heights.Length;

        for (var i = 0; i < volume; i++)
        {
            var j = k;
            var settledIndex = k;

            while (true)
            {
                var originalSettleIndex = settledIndex;
                while (j > 0 && ans[j - 1] <= ans[j])
                {
                    j--;

                    if (ans[j] < ans[settledIndex])
                    {
                        settledIndex = j;
                    }
                }

                while (j < n - 1 && ans[j + 1] <= ans[j])
                {
                    j++;
                    if (ans[j] < ans[settledIndex])
                    {
                        settledIndex = j;
                    }
                }

                if (originalSettleIndex == settledIndex)
                {
                    break;
                }
            }

            ans[settledIndex]++;
        }

        return ans;
    }
}
