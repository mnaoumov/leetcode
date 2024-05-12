using JetBrains.Annotations;

namespace LeetCode._2826_Sorting_Three_Groups;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-111/submissions/detail/1025816087/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(IList<int> nums)
    {
        var pq = new PriorityQueue<(int index, int minGroup, int operationsCount), int>();
        pq.Enqueue((0, 1, 0), 0);

        while (true)
        {
            var (index, minGroup, operationsCount) = pq.Dequeue();

            if (index == nums.Count)
            {
                return operationsCount;
            }

            var group = nums[index];

            if (group >= minGroup)
            {
                pq.Enqueue((index + 1, group, operationsCount), operationsCount);
            }

            if (group != minGroup)
            {
                pq.Enqueue((index + 1, minGroup, operationsCount + 1), operationsCount + 1);
            }
        }
    }
}
