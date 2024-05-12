using JetBrains.Annotations;

namespace LeetCode._2519_Count_the_Number_of_K_Big_Indices;

/// <summary>
/// https://leetcode.com/submissions/detail/869923175/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KBigIndices(int[] nums, int k)
    {
        var greaterIndices = GetKBigGreaterIndices(nums, k);
        var lessIndices = GetKBigGreaterIndices(nums.Reverse(), k)
            .Select(reverseIndex => nums.Length - 1 - reverseIndex);

        var indices = greaterIndices.ToHashSet();
        indices.IntersectWith(lessIndices);
        return indices.Count;
    }

    private static IEnumerable<int> GetKBigGreaterIndices(IEnumerable<int> nums, int k)
    {
        var pq = new PriorityQueue<int, int>();

        var index = 0;

        foreach (var num in nums)
        {
            if (pq.Count >= k)
            {
                var max = pq.Peek();

                if (num > max)
                {
                    yield return index;
                }
            }

            pq.Enqueue(num, -num);

            if (pq.Count > k)
            {
                pq.Dequeue();
            }

            index++;
        }
    }
}
