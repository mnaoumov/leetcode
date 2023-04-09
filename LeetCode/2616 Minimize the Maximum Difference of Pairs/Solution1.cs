using JetBrains.Annotations;

namespace LeetCode._2616_Minimize_the_Maximum_Difference_of_Pairs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-340/submissions/detail/930497583/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimizeMax(int[] nums, int p)
    {
        Array.Sort(nums);

        var pq = new PriorityQueue<int, int>();
        var n = nums.Length;

        var diffs = new List<int>();

        for (var i = 0; i < n - 1; i++)
        {
            var diff = nums[i + 1] - nums[i];
            pq.Enqueue(diff, diff);
        }

        var result = 0;

        var removedDiffs = new Dictionary<int, int>();

        for (var i = 0; i < p; i++)
        {
            int diff;

            while (true)
            {
                diff = pq.Dequeue();

                if (!removedDiffs.ContainsKey(diff))
                {
                    break;
                }

                removedDiffs[diff]--;

                if (removedDiffs[diff] == 0)
                {
                    removedDiffs.Remove(diff);
                }
            }

            result += diff;

            var low = 0;
            var high = diffs.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (diffs[mid] >= diff)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

                if (low == 0)
                {
                    Remove(0);
                }
                else if (low == diffs.Count - 1)
                {
                    Remove(diffs.Count - 2);
                }
                else
                {
                    diffs[low - 1] += diffs[low] + diffs[low + 1];
                    Remove(low);
                }
            }

        }

        return result;

        void Remove(int index)
        {
            var diff1 = diffs[index];
            var diff2 = diffs[index + 1];
            removedDiffs[diff1] = removedDiffs.GetValueOrDefault(diff1) + 1;
            removedDiffs[diff2] = removedDiffs.GetValueOrDefault(diff2) + 1;
            diffs.RemoveRange(index, 2);
        }
    }
}
