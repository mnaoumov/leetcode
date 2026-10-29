namespace LeetCode.Problems._1151_Minimum_Swaps_to_Group_All_1_s_Together;

/// <summary>
/// https://leetcode.com/submissions/detail/943291802/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSwaps(int[] data)
    {
        var totalOnesCount = data.Count(num => num == 1);
        var zerosCount = data.Take(totalOnesCount).Count(num => num == 0);
        var ans = zerosCount;

        for (var i = totalOnesCount; i < data.Length; i++)
        {
            if (data[i] == 0)
            {
                zerosCount++;
            }

            if (data[i - totalOnesCount] == 0)
            {
                zerosCount--;
            }

            ans = Math.Min(ans, zerosCount);
        }

        return ans;
    }
}
