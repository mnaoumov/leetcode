using JetBrains.Annotations;

namespace LeetCode._3137_Minimum_Number_of_Operations_to_Make_Word_K_Periodic;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-396/submissions/detail/1249543900/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperationsToMakeKPeriodic(string word, int k)
    {
        var counts = new Dictionary<string, int>();
        var n = word.Length;
        var maxCount = 0;

        for (var i = 0; i < n; i += k)
        {
            var substring = word[i..(i + k)];
            counts.TryAdd(substring, 0);
            counts[substring]++;
            maxCount = Math.Max(maxCount, counts[substring]);
        }

        return n / k - maxCount;
    }
}
