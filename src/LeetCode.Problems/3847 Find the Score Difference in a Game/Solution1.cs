namespace LeetCode.Problems._3847_Find_the_Score_Difference_in_a_Game;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-490/problems/find-the-score-difference-in-a-game/submissions/1926868722/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ScoreDifference(int[] nums)
    {
        var scores = new[] { 0, 0 };

        var activeUserIndex = 0;

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];

            if (num % 2 == 1)
            {
                activeUserIndex ^= 1;
            }

            if ((index + 1) % 6 == 0)
            {
                activeUserIndex ^= 1;
            }

            scores[activeUserIndex] += num;
        }

        return scores[0] - scores[1];
    }
}
