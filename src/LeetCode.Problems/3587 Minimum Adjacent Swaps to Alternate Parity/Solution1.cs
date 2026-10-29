namespace LeetCode.Problems._3587_Minimum_Adjacent_Swaps_to_Alternate_Parity;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-159/problems/minimum-adjacent-swaps-to-alternate-parity/submissions/1671632700/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSwaps(int[] nums)
    {
        var n = nums.Length;

        var evenCount = nums.Count(x => x % 2 == 0);
        var oddCount = n - evenCount;

        var ans = int.MaxValue;

        foreach (var firstParity in new[] { 0, 1 })
        {
            var firstParityCount = firstParity == 0 ? evenCount : oddCount;
            var secondParityCount = n - firstParityCount;

            if (firstParityCount != secondParityCount && firstParityCount != secondParityCount + 1)
            {
                continue;
            }

            var swaps = 0;
            var indices = Enumerable.Range(0, 2).Select(_ => new Queue<int>()).ToArray();

            for (var i = 0; i < n; i++)
            {
                var expectedParity = (firstParity + i) % 2;
                var actualParity = nums[i] % 2;

                if (expectedParity == actualParity)
                {
                    continue;
                }

                if (indices[1 - actualParity].Count > 0)
                {
                    var index = indices[1 - actualParity].Dequeue();
                    swaps += i - index;
                }
                else
                {
                    indices[actualParity].Enqueue(i);
                }
            }

            ans = Math.Min(ans, swaps);
        }

        const int impossible = -1;
        return ans == int.MaxValue ? impossible : ans;
    }
}
