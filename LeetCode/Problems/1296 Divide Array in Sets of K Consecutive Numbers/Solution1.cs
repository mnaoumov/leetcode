using JetBrains.Annotations;

namespace LeetCode.Problems._1296_Divide_Array_in_Sets_of_K_Consecutive_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/1299460069/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPossibleDivide(int[] nums, int k)
    {
        if (nums.Length % k != 0)
        {
            return false;
        }

        var counts = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var sorted = new SortedSet<int>(counts.Keys);

        while (sorted.Count > 0)
        {
            var min = sorted.Min;

            for (var j = 0; j < k; j++)
            {
                var num = min + j;

                if (!counts.TryGetValue(num, out var count))
                {
                    return false;
                }

                if (count > 1)
                {
                    counts[num] = count - 1;
                    continue;
                }

                counts.Remove(num);
                sorted.Remove(num);
            }
        }

        return true;
    }
}
