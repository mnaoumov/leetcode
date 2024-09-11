
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0967_Numbers_With_Same_Consecutive_Differences;

/// <summary>
/// https://leetcode.com/submissions/detail/200392813/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] NumsSameConsecDiff(int N, int K)
    {
        if (N == 1)
        {
            return Enumerable.Range(0, 10).ToArray();
        }

        var results = Enumerable.Range(1, 9).ToList();
        for (int i = 1; i < N; i++)
        {
            var nextResults = new List<int>();
            foreach (var result in results)
            {
                var digit = result % 10;
                if (K != 0 && digit >= K)
                {
                    nextResults.Add(10 * result + digit - K);
                }

                if (digit <= 9 - K)
                {
                    nextResults.Add(10 * result + digit + K);
                }
            }

            results = nextResults;
        }

        return results.ToArray();
    }
}
