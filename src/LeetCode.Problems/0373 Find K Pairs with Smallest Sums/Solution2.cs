namespace LeetCode.Problems._0373_Find_K_Pairs_with_Smallest_Sums;

/// <summary>
/// https://leetcode.com/submissions/detail/908515246/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var heap = new PriorityQueue<(int index1, int index2), int>();
        var set = new HashSet<(int index1, int index2)>();
        Enqueue(0, 0);

        var result = new List<IList<int>>();

        for (var i = 0; i < k; i++)
        {
            if (heap.Count == 0)
            {
                break;
            }

            var (index1, index2) = heap.Dequeue();
            result.Add(new[] { nums1[index1], nums2[index2] });
            Enqueue(index1 + 1, index2);
            Enqueue(index1, index2 + 1);
        }

        return result;

        void Enqueue(int index1, int index2)
        {
            if (index1 >= nums1.Length || index2 >= nums2.Length || !set.Add((index1, index2)))
            {
                return;
            }

            var sum = nums1[index1] + nums2[index2];
            heap.Enqueue((index1, index2), sum);
        }
    }
}
