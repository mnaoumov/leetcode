namespace LeetCode.Problems._3741_Minimum_Distance_Between_Three_Equal_Elements_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-475/problems/minimum-distance-between-three-equal-elements-ii/submissions/1824628308/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDistance(int[] nums)
    {
        var indicesMap = new Dictionary<int, Queue<int>>();

        var ans = int.MaxValue;

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];
            indicesMap.TryAdd(num, new Queue<int>());
            indicesMap[num].Enqueue(index);

            if (indicesMap[num].Count > 3)
            {
                indicesMap[num].Dequeue();
            }

            if (indicesMap[num].Count == 3)
            {
                ans = Math.Min(ans, 2 * (index - indicesMap[num].Peek()));
            }
        }

        if (ans == int.MaxValue)
        {
            ans = -1;
        }

        return ans;
    }
}
