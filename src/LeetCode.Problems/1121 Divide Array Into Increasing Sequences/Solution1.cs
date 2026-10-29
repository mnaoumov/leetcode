namespace LeetCode.Problems._1121_Divide_Array_Into_Increasing_Sequences;

/// <summary>
/// https://leetcode.com/problems/divide-array-into-increasing-sequences/submissions/1785918403/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanDivideIntoSubsequences(int[] nums, int k)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var maxCount = counts.Values.Max();

        if (maxCount * k > nums.Length)
        {
            return false;
        }

        var subsequences = Enumerable.Range(0, maxCount).Select(_ => new List<int>()).ToList();
        var pq = new PriorityQueue<int, int>();

        for (var i = 0; i < maxCount; i++)
        {
            pq.Enqueue(i, 0);
        }

        foreach (var num in nums)
        {
            var skippedSubsequenceIndices = new List<int>();
            const int notFoundIndex = -1;
            var targetSubsequenceIndex = notFoundIndex;

            while (pq.Count > 0)
            {
                var subsequenceIndex = pq.Dequeue();

                if (subsequences[subsequenceIndex].Count > 0 && subsequences[subsequenceIndex][^1] == num)
                {
                    skippedSubsequenceIndices.Add(subsequenceIndex);
                }
                else
                {
                    targetSubsequenceIndex = subsequenceIndex;
                    break;
                }
            }

            if (targetSubsequenceIndex == -1)
            {
                subsequences.Add(new List<int>());
                targetSubsequenceIndex = subsequences.Count - 1;
            }

            subsequences[targetSubsequenceIndex].Add(num);
            pq.Enqueue(targetSubsequenceIndex, subsequences[targetSubsequenceIndex].Count);

            foreach (var skippedSubsequenceIndex in skippedSubsequenceIndices)
            {
                pq.Enqueue(skippedSubsequenceIndex, subsequences[skippedSubsequenceIndex].Count);
            }
        }

        return subsequences.All(subsequence => subsequence.Count >= k);
    }
}
