namespace LeetCode.Problems._3942_Minimum_Operations_to_Sort_a_Permutation;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-sort-a-permutation/submissions/2178445179/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return 0;
        }

        var p = nums.IndexOf(0);

        var isDirectPermutation = Enumerable.Range(0, n).All(i => nums[i] == (i - p + n) % n);
        var isReversePermutation = Enumerable.Range(0, n).All(i => nums[i] == (n + p - i) % n);

        if (!isDirectPermutation && !isReversePermutation)
        {
            return -1;
        }

        var seen = new HashSet<Entry>();

        var queue = new Queue<Entry>();
        queue.Enqueue(new Entry(true, 0));

        var ans = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var entry = queue.Dequeue();

                if (!seen.Add(entry))
                {
                    continue;
                }

                if (isDirectPermutation && entry.IsDirectPermutation && nums[entry.Offset] == 0 || isReversePermutation && !entry.IsDirectPermutation && nums[n - 1 - entry.Offset] == 0)
                {
                    return ans;
                }

                queue.Enqueue(new Entry(!entry.IsDirectPermutation, (n - entry.Offset) % n));
                queue.Enqueue(entry with { Offset = (entry.Offset + 1) % n });
            }

            ans++;
        }

        return -1;
    }

    private sealed record Entry(bool IsDirectPermutation, int Offset);
}
