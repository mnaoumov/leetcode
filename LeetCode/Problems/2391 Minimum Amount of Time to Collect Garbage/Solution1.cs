using JetBrains.Annotations;

namespace LeetCode._2391_Minimum_Amount_of_Time_to_Collect_Garbage;

/// <summary>
/// https://leetcode.com/submissions/detail/1102508361/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        var garbageTypes = new[] { 'M', 'P', 'G' };

        var lastIndices = new Dictionary<char, int>();

        foreach (var garbageType in garbageTypes)
        {
            lastIndices[garbageType] = -1;
        }

        var n = garbage.Length;

        var countMap = new Dictionary<char, int>();

        foreach (var garbageType in garbageTypes)
        {
            countMap[garbageType] = 0;
        }

        var counts = Enumerable.Range(0, n).Select(_ => countMap.ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
            .ToArray();

        for (var i = 0; i < garbage.Length; i++)
        {
            var garbageUnits = garbage[i];

            foreach (var garbageUnit in garbageUnits.ToCharArray())
            {
                lastIndices[garbageUnit] = i;
                counts[i][garbageUnit]++;
            }
        }

        var ans = 0;

        foreach (var garbageType in garbageTypes)
        {
            var lastIndex = lastIndices[garbageType];

            for (var i = 0; i <= lastIndex; i++)
            {
                ans += counts[i][garbageType];

                if (i < lastIndex)
                {
                    ans += travel[i];
                }
            }
        }

        return ans;
    }
}
