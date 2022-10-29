using JetBrains.Annotations;

namespace LeetCode._2136_Earliest_Possible_Day_of_Full_Bloom;

/// <summary>
/// https://leetcode.com/submissions/detail/832973774/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EarliestFullBloom(int[] plantTime, int[] growTime)
    {
        var ordered = plantTime
            .Zip(growTime, (plantTimeValue, growTimeValue) => (plantTimeValue, growTimeValue))
            .OrderByDescending(x => x.growTimeValue)
            .ToArray();

        var plantTimeline = 0;
        var result = 0;

        foreach (var (plantTimeValue, growTimeValue) in ordered)
        {
            plantTimeline += plantTimeValue;
            result = Math.Max(result, plantTimeline + growTimeValue);
        }

        return result;
    }
}
