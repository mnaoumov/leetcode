using JetBrains.Annotations;

namespace LeetCode.Problems._2501_Longest_Square_Streak_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/858997990/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestSquareStreak(int[] nums)
    {
        var limit = (int) Math.Sqrt(int.MaxValue);

        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

        var streaks = new Dictionary<int, int>();

        var result = nums.Select(GetStreak).Prepend(1).Max();

        return result == 1 ? -1 : result;

        int GetStreak(int num)
        {
            if (streaks.TryGetValue(num, out var streak))
            {
                return streak;
            }

            if (!counts.TryGetValue(num, out var count))
            {
                return streaks[num] = 0;
            }

            if (num is 0 or 1)
            {
                return streaks[num] = count;
            }

            if (num > limit || num < -limit)
            {
                return streaks[num] = 1;
            }

            return streaks[num] = GetStreak(num * num) + 1;
        }
    }
}
