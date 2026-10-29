namespace LeetCode.Problems._3942_Minimum_Operations_to_Sort_a_Permutation;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-sort-a-permutation/submissions/2178421862/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;
        var sortedStr = string.Join(' ', Enumerable.Range(0, n));

        var seen = new HashSet<string>();

        var queue = new Queue<(bool isReverse, int offset)>();
        queue.Enqueue((false, 0));

        var ans = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var (isReverse, offset) = queue.Dequeue();
                var indices = GetIndices(n, isReverse, offset);
                var permutation = indices.Select(j => nums[j]);
                var str = string.Join(' ', permutation);

                if (str == sortedStr)
                {
                    return ans;
                }

                if (!seen.Add(str))
                {
                    continue;
                }

                queue.Enqueue((!isReverse, (n - offset) % n));

                if (offset + 1 < n)
                {
                    queue.Enqueue((isReverse, offset + 1));
                }
            }

            ans++;
        }

        return -1;
    }

    private static IEnumerable<int> GetIndices(int n, bool isReverse, int offset)
    {
        return isReverse
            ? Enumerable.Range(0, n - offset).Reverse().Concat(Enumerable.Range(n - offset, offset).Reverse())
            : Enumerable.Range(offset, n - offset).Concat(Enumerable.Range(0, offset));
    }
}
