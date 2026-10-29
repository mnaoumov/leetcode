namespace LeetCode.Problems._0781_Rabbits_in_Forest;

/// <summary>
/// https://leetcode.com/problems/rabbits-in-forest/submissions/1611943340/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumRabbits(int[] answers)
    {
        var answerCounts = answers.GroupBy(answer => answer).ToDictionary(g => g.Key, g => g.Count());

        var ans = 0;

        foreach (var (answer, count) in answerCounts)
        {
            ans += (count + answer) / (answer + 1) * (answer + 1);
        }

        return ans;
    }
}
