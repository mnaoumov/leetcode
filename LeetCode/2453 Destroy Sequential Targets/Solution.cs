using JetBrains.Annotations;

namespace LeetCode._2453_Destroy_Sequential_Targets;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-90/submissions/detail/832724318/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DestroyTargets(int[] nums, int space)
    {
        var dict = new Dictionary<int, (int count, int minRepresentative)>();

        foreach (var num in nums)
        {
            var remainder = num % space;

            if (!dict.ContainsKey(remainder))
            {
                dict[remainder] = (0, int.MaxValue);
            }

            dict[remainder] = (dict[remainder].count + 1, Math.Min(dict[remainder].minRepresentative, num));
        }

        return dict.Values.GroupBy(x => x.count).MaxBy(g => g.Key)!.Select(g => g.minRepresentative).Min();
    }
}
