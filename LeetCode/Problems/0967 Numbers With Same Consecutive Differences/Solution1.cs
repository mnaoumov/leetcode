using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0967_Numbers_With_Same_Consecutive_Differences;

/// <summary>
/// https://leetcode.com/submissions/detail/200391901/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] NumsSameConsecDiff(int N, int K)
    {
        var results = Enumerable.Range(1, 9).ToList();
        for (int i = 1; i < N; i++)
        {
            var nextResults = new List<int>();
            foreach (var result in results)
            {
                var digit = result % 10;
                if (digit >= K)
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
