using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._1207_Unique_Number_of_Occurrences;

/// <summary>
/// https://leetcode.com/submissions/detail/852015898/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool UniqueOccurrences(int[] arr)
    {
        var countsMap = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            countsMap[num] = countsMap.GetValueOrDefault(num) + 1;
        }

        var countsSet = new HashSet<int>();

        foreach (var count in countsMap.Values)
        {
            if (!countsSet.Add(count))
            {
                return false;
            }
        }

        return true;
    }
}