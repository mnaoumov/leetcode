namespace LeetCode.Problems._3752_Lexicographically_Smallest_Negated_Permutation_that_Sums_to_Target;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-170/problems/lexicographically-smallest-negated-permutation-that-sums-to-target/submissions/1836866519/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] LexSmallestNegatedPerm(int n, long target)
    {
        var sum = 1L * n * (n + 1) / 2;

        var diff = sum - target;

        if (diff % 2 != 0)
        {
            return Array.Empty<int>();
        }

        diff /= 2;

        if (diff < 0 || diff > sum)
        {
            return Array.Empty<int>();
        }

        var list = new List<int>();
        var maxAvailable = n;
        var set = new HashSet<int>();

        while (diff > 0)
        {
            var num = (int) Math.Min(maxAvailable, diff);
            diff -= num;
            list.Add(-num);
            set.Add(num);
            maxAvailable = num - 1;
        }

        for (var i = 1; i <= n; i++)
        {
            if (!set.Contains(i))
            {
                list.Add(i);
            }
        }

        return list.ToArray();
    }
}
