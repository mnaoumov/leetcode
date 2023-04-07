using JetBrains.Annotations;

namespace LeetCode._0264_Ugly_Number_II;

/// <summary>
/// https://leetcode.com/submissions/detail/929395154/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NthUglyNumber(int n)
    {
        var list = new List<int>
        {
            1
        };

        var multipliers = new[] { 2, 3, 5 };

        var indices = multipliers.ToDictionary(multiplier => multiplier, _ => 0);

        while (list.Count < n)
        {
            var nextGroup = multipliers.GroupBy(multiplier => multiplier * list[indices[multiplier]]).MinBy(g => g.Key)!;
            list.Add(nextGroup.Key);

            foreach (var multiplier in nextGroup)
            {
                indices[multiplier]++;
            }
        }

        return list.Last();
    }
}
