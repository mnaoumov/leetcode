using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2560_House_Robber_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/892718193/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public int MinCapability(int[] nums, int k)
    {
        var queue = new Queue<(int index, int housesToRobCount, int capacity)>();
        queue.Enqueue((0, k, 0));

        var result = int.MaxValue;

        while (queue.Count > 0)
        {
            var (index, housesToRobCount, capacity) = queue.Dequeue();

            if (index + 2 * housesToRobCount > nums.Length + 1)
            {
                continue;
            }

            if (capacity >= result)
            {
                continue;
            }

            if (housesToRobCount == 0)
            {
                result = capacity;
                continue;
            }

            queue.Enqueue((index + 1, housesToRobCount, capacity));

            if (nums[index] < result)
            {
                queue.Enqueue((index + 2, housesToRobCount - 1, Math.Max(capacity, nums[index])));
            }
        }

        return result;
    }
}
