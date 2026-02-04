namespace LeetCode.Problems._3621_Number_of_Integers_With_Popcount_Depth_Equal_to_K_I;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long PopcountDepth(long n, int k)
    {
        if (k == 0)
        {
            return 1;
        }

        if (n == 1)
        {
            return 0;
        }

        var bitsCount = (int) Math.Ceiling(Math.Log2(n));
        var popCounts = GetPossiblePopcounts(bitsCount, k - 1);

        var ans = 0L;

        foreach (var popCount in popCounts)
        {
            ans += Choose(bitsCount, popCount);
        }

        return ans;
    }

    private long Choose(int bitsCount, int popCount)
    {
        return bitsCount + popCount;
    }

    private static IEnumerable<int> GetPossiblePopcounts(int n, int depth)
    {
        for (var i = 0; i <= n; i++)
        {
            if (GetPopcountDepth(i) == depth)
            {
                yield return i;
            }
        }
    }

    private static int GetPopcountDepth(int x)
    {
        var ans = 0;

        while (x > 1)
        {
            ans++;
            x = Popcount(x);
        }

        return ans;
    }

    private static int Popcount(int x)
    {
        var ans = 0;
        while (x > 0)
        {
            ans += x & 1;
            x >>= 1;
        }
        return ans;
    }
}
