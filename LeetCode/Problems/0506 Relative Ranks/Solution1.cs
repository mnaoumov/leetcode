using JetBrains.Annotations;

namespace LeetCode._0506_Relative_Ranks;

/// <summary>
/// https://leetcode.com/submissions/detail/1252750120/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] FindRelativeRanks(int[] score)
    {
        var scoreIndexMap = Enumerable.Range(0, score.Length).ToDictionary(index => score[index]);
        var n = score.Length;
        var ans = new string[n];
        
        var sortedIndex = 0;
        
        foreach (var value in score.OrderByDescending(x => x))
        {
            sortedIndex++;

            var scoreStr = sortedIndex switch
            {
                1 => "Gold Medal",
                2 => "Silver Medal",
                3 => "Bronze Medal",
                _ => sortedIndex.ToString()
            };

            var originalIndex = scoreIndexMap[value];
            ans[originalIndex] = scoreStr;
        }

        return ans;
    }
}
