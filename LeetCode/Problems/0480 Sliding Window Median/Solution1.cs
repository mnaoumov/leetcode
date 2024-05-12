using JetBrains.Annotations;

namespace LeetCode.Problems._0480_Sliding_Window_Median;

/// <summary>
/// https://leetcode.com/submissions/detail/907994712/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        var lowerHalfMaxHeap = new PriorityQueue<int, int>();
        var topHalfMinHeap = new PriorityQueue<int, int>();
        var numsToRemove = new Dictionary<int, int>();
        var numsToRemoveLowerHalfCount = 0;
        var lowerHalfMaxHeapMedianCount = (k + 1) / 2;
        var result = new double[nums.Length - k + 1];

        for (var i = 0; i < nums.Length; i++)
        {
            {
                var num = nums[i];

                if (lowerHalfMaxHeap.TryPeek(out var max, out _) && num <= max)
                {
                    lowerHalfMaxHeap.Enqueue(num, -num);
                }
                else
                {
                    topHalfMinHeap.Enqueue(num, num);
                }
            }

            if (i >= k)
            {
                var numToRemove = nums[i - k];
                numsToRemove[numToRemove] = numsToRemove.GetValueOrDefault(numToRemove) + 1;

                if (lowerHalfMaxHeap.TryPeek(out var max, out _) && numToRemove <= max)
                {
                    numsToRemoveLowerHalfCount++;
                }

                numsToRemoveLowerHalfCount -= CleanRemovedNums(lowerHalfMaxHeap);
                CleanRemovedNums(topHalfMinHeap);
            }

            if (i < k - 1)
            {
                continue;
            }

            {
                while (lowerHalfMaxHeap.Count - numsToRemoveLowerHalfCount > lowerHalfMaxHeapMedianCount)
                {
                    var num = lowerHalfMaxHeap.Dequeue();
                    topHalfMinHeap.Enqueue(num, num);
                    numsToRemoveLowerHalfCount -= CleanRemovedNums(lowerHalfMaxHeap);
                }

                while (lowerHalfMaxHeap.Count - numsToRemoveLowerHalfCount < lowerHalfMaxHeapMedianCount)
                {
                    var num = topHalfMinHeap.Dequeue();
                    lowerHalfMaxHeap.Enqueue(num, -num);
                    CleanRemovedNums(topHalfMinHeap);
                }

                result[i - k + 1] = k % 2 == 1
                    ? lowerHalfMaxHeap.Peek()
                    : (lowerHalfMaxHeap.Peek() + topHalfMinHeap.Peek()) / 2.0;
            }
        }

        return result;

        int CleanRemovedNums(PriorityQueue<int, int> heap)
        {
            var removedCount = 0;
            while (heap.TryPeek(out var num, out _) && numsToRemove.ContainsKey(num))
            {
                heap.Dequeue();
                numsToRemove[num]--;
                removedCount++;

                if (numsToRemove[num] == 0)
                {
                    numsToRemove.Remove(num);
                }
            }

            return removedCount;
        }
    }
}
