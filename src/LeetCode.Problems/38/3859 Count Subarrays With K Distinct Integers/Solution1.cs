namespace LeetCode.Problems._3859_Count_Subarrays_With_K_Distinct_Integers;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-491/problems/count-subarrays-with-k-distinct-integers/submissions/1934278168/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long CountSubarrays(int[] nums, int k, int m)
    {
        var n = nums.Length;
        var i = 0;
        var counts = new Dictionary<int, int>();
        var countNumPairs = new SortedSet<(int count, int num)>();

        var ans = 0;

        for (var j = 0; j < n; j++)
        {
            var num = nums[j];
            counts.TryAdd(num, 0);
            countNumPairs.Remove((counts[num], num));
            counts[num]++;
            countNumPairs.Add((counts[num], num));

            while (counts.Count > k)
            {
                var oldNum = nums[i];
                countNumPairs.Remove((counts[oldNum], oldNum));
                counts[oldNum]--;

                if (counts[oldNum] == 0)
                {
                    counts.Remove(oldNum);
                }
                else
                {
                    countNumPairs.Add((counts[oldNum], oldNum));
                }

                i++;
            }

            if (countNumPairs.Count == k && countNumPairs.Min.count >= m)
            {
                ans++;
            }
        }

        return ans;
    }
}
