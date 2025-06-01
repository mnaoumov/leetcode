namespace LeetCode.Problems._3362_Zero_Array_Transformation_III;

/// <summary>
/// https://leetcode.com/problems/zero-array-transformation-iii/submissions/1641365806/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxRemoval(int[] nums, int[][] queries)
    {
        var n = nums.Length;
        var queryObjs = queries
            .Select(query => new Query(query[0], query[1]))
            .OrderBy(q => q.FromIndex)
            .ToArray();

        var queryIndex = 0;
        var pq = new PriorityQueue<int, int>();
        var operations = 0;
        var deltas = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            operations += deltas[i];

            while (queryIndex < queryObjs.Length && queryObjs[queryIndex].FromIndex == i)
            {
                var toIndex = queryObjs[queryIndex].ToIndex;
                pq.Enqueue(toIndex, -toIndex);
                queryIndex++;
            }

            while (operations < nums[i] && pq.Count > 0)
            {
                var toIndex = pq.Dequeue();
                if (toIndex < i)
                {
                    break;
                }

                operations++;
                deltas[toIndex + 1]--;
            }

            if (operations < nums[i])
            {
                return -1;
            }
        }

        return pq.Count;
    }

    private record Query(int FromIndex, int ToIndex);
}
