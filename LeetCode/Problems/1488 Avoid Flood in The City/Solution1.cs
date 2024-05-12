using JetBrains.Annotations;

namespace LeetCode.Problems._1488_Avoid_Flood_in_The_City;

/// <summary>
/// https://leetcode.com/submissions/detail/965605506/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] AvoidFlood(int[] rains)
    {
        var n = rains.Length;
        var fullLakes = new HashSet<int>();
        var ans = new int[n];
        var noRainDays = new List<int>();
        var lastDryDayMap = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var lake = rains[i];

            if (lake > 0)
            {
                if (!fullLakes.Add(lake))
                {
                    var minNextDryDay = lastDryDayMap.GetValueOrDefault(lake, -1) + 1;

                    var index = noRainDays.BinarySearch(minNextDryDay);

                    if (index < 0)
                    {
                        index = ~index;
                    }
                    
                    if (index == noRainDays.Count)
                    {
                        return Array.Empty<int>();
                    }

                    var noRainDay = noRainDays[index];
                    ans[noRainDay] = lake;
                    lastDryDayMap[lake] = noRainDay;
                    noRainDays.RemoveAt(index);
                }

                ans[i] = -1;
            }
            else
            {
                noRainDays.Add(i);
            }
        }

        return ans;
    }
}
