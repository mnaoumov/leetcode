using JetBrains.Annotations;

namespace LeetCode.Problems._2599_Make_the_Prefix_Sum_Non_negative;

/// <summary>
/// https://leetcode.com/submissions/detail/920499809/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public int MakePrefSumNonNegative(int[] nums)
    {
        var prefixSum = 0;
        var list = nums.ToList();
        var result = 0;
        var pq = new PriorityQueue<int, int>();

        for (var i = 0; i < list.Count; i++)
        {
            var num = list[i];
            prefixSum += num;
            pq.Enqueue(num, num);

            if (prefixSum >= 0)
            {
                continue;
            }

            var min = pq.Dequeue();

            list.Add(min);
            result++;
            prefixSum -= min;
        }

        return result;
    }
}
