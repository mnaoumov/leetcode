namespace LeetCode.Problems._2974_Minimum_Number_Game;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-377/submissions/detail/1127035861/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] NumberGame(int[] nums)
    {
        Array.Sort(nums);
        var list = new List<int>();

        for (var aliceNumIndex = 0; aliceNumIndex < nums.Length; aliceNumIndex += 2)
        {
            var aliceNum = nums[aliceNumIndex];
            var bobNum = nums[aliceNumIndex + 1];
            list.Add(bobNum);
            list.Add(aliceNum);
        }

        return list.ToArray();
    }
}
