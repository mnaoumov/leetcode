namespace LeetCode.Problems._3755_Find_Maximum_Balanced_XOR_Subarray_Length;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-477/problems/find-maximum-balanced-xor-subarray-length/submissions/1837280276/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxBalancedSubarray(int[] nums)
    {
        var map = new Dictionary<Entry, int>
        {
            [new Entry(0, 0)] = -1
        };

        var xor = 0;
        var evenOddCountDiff = 0;
        var ans = 0;

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];
            xor ^= num;

            if (num % 2 == 0)
            {
                evenOddCountDiff++;
            }
            else
            {
                evenOddCountDiff--;
            }

            var entry = new Entry(xor, evenOddCountDiff);

            if (map.TryGetValue(entry, out var previousIndex))
            {
                ans = Math.Max(ans, index - previousIndex);
            }
            else
            {
                map[entry] = index;
            }
        }

        return ans;
    }

    private record Entry(int Xor, int EvenOddCountDiff);
}
