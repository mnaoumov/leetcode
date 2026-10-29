namespace LeetCode.Problems._2210_Count_Hills_and_Valleys_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/count-hills-and-valleys-in-an-array/submissions/1712960750/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountHillValley(int[] nums)
    {
        var list = new List<int>();

        foreach (var num in nums)
        {
            if (list.Count == 0 || list[^1] != num)
            {
                list.Add(num);
            }
        }

        var ans = 0;

        for (var i = 1; i < list.Count - 1; i++)
        {
            if (list[i] < list[i - 1] && list[i] < list[i + 1] ||
                list[i] > list[i - 1] && list[i] > list[i + 1])
            {
                ans++;
            }
        }

        return ans;
    }
}
