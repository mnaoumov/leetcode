namespace LeetCode.Problems._3445_Maximum_Difference_Between_Even_and_Odd_Frequency_II;

/// <summary>
/// https://leetcode.com/problems/maximum-difference-between-even-and-odd-frequency-ii/submissions/1672067913/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaxDifference(string s, int k)
    {
        var n = s.Length;
        var ans = int.MinValue;
        var digits = new[] { '0', '1', '2', '3', '4' };
        const int unknown = int.MaxValue;

        foreach (var a in digits)
        {
            foreach (var b in digits)
            {
                if (a == b)
                {
                    continue;
                }
                var best = new int[4];
                Array.Fill(best, unknown);
                var countA = 0;
                var countB = 0;
                var previousCountA = 0;
                var previousCountB = 0;
                var left = -1;
                for (var right = 0; right < n; right++)
                {
                    if (s[right] == a)
                    {
                        countA++;
                    }
                    if (s[right] == b)
                    {
                        countB++;
                    }
                    while (right - left >= k && countB - previousCountB >= 2)
                    {
                        var leftMask = GetParityMask(previousCountA, previousCountB);
                        best[leftMask] = Math.Min(best[leftMask], previousCountA - previousCountB);
                        left++;
                        if (s[left] == a)
                        {
                            previousCountA++;
                        }
                        if (s[left] == b)
                        {
                            previousCountB++;
                        }
                    }
                    var rightMask = GetParityMask(countA, countB);
                    var previousResult = best[rightMask ^ 0b10];

                    if (previousResult != unknown)
                    {
                        ans = Math.Max(ans, countA - countB - previousResult);
                    }
                }
            }
        }
        return ans;
    }

    private static int GetParityMask(int countA, int countB) => (countA & 1) << 1 | countB & 1;
}