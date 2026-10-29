namespace LeetCode.Problems._3755_Find_Maximum_Balanced_XOR_Subarray_Length;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-477/problems/find-maximum-balanced-xor-subarray-length/submissions/1837266672/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxBalancedSubarray(int[] nums)
    {
        var map = new Dictionary<int, List<Entry>>
        {
            [0] = new() { new Entry(-1, 0, 0) }
        };

        var xor = 0;
        var evenCount = 0;
        var oddCount = 0;
        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            xor ^= num;

            if (num % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }

            map.TryAdd(xor, new List<Entry>());

            var entry = map[xor].FirstOrDefault(entry => evenCount - entry.EvenCount == oddCount - entry.OddCount);

            if (entry != null)
            {
                ans = Math.Max(ans, i - entry.Index);
            }

            map[xor].Add(new Entry(i, evenCount, oddCount));
        }

        return ans;
    }

    private record Entry(int Index, int EvenCount, int OddCount);
}
