using JetBrains.Annotations;

namespace LeetCode._2279_Maximum_Bags_With_Full_Capacity_of_Rocks;

/// <summary>
/// https://leetcode.com/submissions/detail/866046315/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
    {
        var spaces = capacity.Zip(rocks, (aCapacity, rock) => aCapacity - rock).ToArray();
        Array.Sort(spaces);

        var result = 0;

        foreach (var space in spaces)
        {
            if (space > additionalRocks)
            {
                break;
            }

            result++;
            additionalRocks -= space;
        }

        return result;
    }
}
