namespace LeetCode.Problems._2940_Find_Building_Where_Alice_and_Bob_Can_Meet;

/// <summary>
/// https://leetcode.com/submissions/detail/1487479667/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution6 : ISolution
{
    private const int N = (int) 5e4 + 1;
    private const int M = 17;
    private static readonly double Log2 = Math.Log(2);
    private readonly int[,] _f = new int[N, M];

    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        var n = heights.Length;
        var m = queries.Length;

        Init();
        var qwq = new int[m];

        for (var i = 0; i < m; i++)
        {
            var a = queries[i][0];
            var b = queries[i][1];
            (a, b) = (Math.Min(a, b), Math.Max(a, b));

            if (heights[a] < heights[b] && a < b || a == b)
            {
                qwq[i] = b;
            }
            else
            {
                var l = Math.Max(a, b);
                var r = n;

                while (l < r)
                {
                    var mid = l + r >> 1;

                    if (Query(l + 1, mid + 1) > Math.Max(heights[a], heights[b]))
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                qwq[i] = l <= Math.Min(a, b) || l >= n ? -1 : l;
            }
        }
        return qwq;

        int Query(int l, int r)
        {
            var len = r - l + 1;
            var k = (int) (Math.Log(len) / Log2);
            return Math.Max(_f[l, k], _f[r - (1 << k) + 1, k]);
        }

        void Init()
        {
            for (var j = 0; j < M; j++)
            {
                for (var i = 1; i + (1 << j) - 1 <= n; i++)
                {
                    if (j <= 0)
                    {
                        _f[i, j] = heights[i - 1];
                    }
                    else
                    {
                        _f[i, j] = Math.Max(_f[i, j - 1], _f[i + (1 << j - 1), j - 1]);
                    }
                }
            }
        }
    }
}