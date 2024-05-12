using JetBrains.Annotations;

namespace LeetCode.Problems._1488_Avoid_Flood_in_The_City;

/// <summary>
/// https://leetcode.com/submissions/detail/965612265/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] AvoidFlood(int[] rains)
    {
        var n = rains.Length;
        var fullLakes = new HashSet<int>();
        var ans = new int[n];
        var noRainDays = new List<int>();
        var lastFilledDayMap = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var lake = rains[i];

            if (lake > 0)
            {
                if (!fullLakes.Add(lake))
                {
                    var minNextDryDay = lastFilledDayMap.GetValueOrDefault(lake, -1) + 1;

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
                    noRainDays.RemoveAt(index);
                }

                lastFilledDayMap[lake] = i;
                ans[i] = -1;
            }
            else
            {
                ans[i] = 1;
                noRainDays.Add(i);
            }
        }

        return ans;
    }
}
