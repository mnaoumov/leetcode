namespace LeetCode.Problems._2599_Make_the_Prefix_Sum_Non_negative;

/// <seealso href="https://leetcode.com/submissions/detail/920500879/"/>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MakePrefSumNonNegative(int[] nums)
    {
        var prefixSum = 0L;
        var list = nums.ToList();
        var result = 0;
        var pq = new PriorityQueue<int, int>();

        for (var i = 0; i < list.Count; i++)
        {
            var num = list[i];
            prefixSum += num;

            if (num < 0)
            {
                pq.Enqueue(num, num);
            }

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
