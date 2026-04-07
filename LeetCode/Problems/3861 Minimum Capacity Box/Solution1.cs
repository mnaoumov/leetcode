namespace LeetCode.Problems._3861_Minimum_Capacity_Box;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-492/problems/minimum-capacity-box/submissions/1941330975/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumIndex(int[] capacity, int itemSize)
    {
        var filtered = capacity.Select((capacityValue, index) => (capacity: capacityValue, index))
            .Where(x => x.capacity >= itemSize).ToArray();
        var minCapacity = filtered.Select(x => x.capacity).Append(int.MaxValue).Min();

        filtered = filtered.Where(x => x.capacity == minCapacity).ToArray();

        const int notFoundIndex = -1;
        return filtered.FirstOrDefault((0, index: notFoundIndex)).index;
    }
}
