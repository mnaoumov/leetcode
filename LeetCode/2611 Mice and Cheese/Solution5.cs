using JetBrains.Annotations;

namespace LeetCode._2611_Mice_and_Cheese;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-339/submissions/detail/926310565/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MiceAndCheese(int[] reward1, int[] reward2, int k)
    {
        var n = reward1.Length;
        var indices1 = Enumerable.Range(0, n).OrderByDescending(index => reward1[index] - reward2[index]).Take(k)
            .ToHashSet();

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            result += indices1.Contains(i) ? reward1[i] : reward2[i];
        }

        return result;
    }
}
