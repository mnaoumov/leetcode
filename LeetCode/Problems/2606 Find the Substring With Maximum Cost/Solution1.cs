using JetBrains.Annotations;

namespace LeetCode._2606_Find_the_Substring_With_Maximum_Cost;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-101/submissions/detail/925972750/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumCostSubstring(string s, string chars, int[] vals)
    {
        var valueMap = chars.Zip(vals, (letter, value) => (letter, value)).ToDictionary(x => x.letter, x => x.value);
        var result = 0;
        var cost = 0;

        foreach (var value in s.Select(letter => valueMap.GetValueOrDefault(letter, letter - 'a' + 1)))
        {
            cost = Math.Max(cost + value, 0);
            result = Math.Max(result, cost);
        }

        return result;
    }
}
