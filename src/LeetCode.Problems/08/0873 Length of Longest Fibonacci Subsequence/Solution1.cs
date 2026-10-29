namespace LeetCode.Problems._0873_Length_of_Longest_Fibonacci_Subsequence;

/// <summary>
/// https://leetcode.com/problems/length-of-longest-fibonacci-subsequence/submissions/1556617984/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        var n = arr.Length;
        var set = arr.ToHashSet();

        var ans = 0;

        for (var i = 0; i < n - 2; i++)
        {
            var prev = arr[i];

            for (var j = i + 1; j < n - 1; j++)
            {
                var current = arr[j];
                var length = 2;

                while (true)
                {
                    var next = prev + current;

                    if (!set.Contains(next))
                    {
                        break;
                    }

                    (prev, current) = (current, next);
                    length++;
                }

                if (length >= 3)
                {
                    ans = Math.Max(ans, length);
                }
            }
        }

        return ans;
    }
}
