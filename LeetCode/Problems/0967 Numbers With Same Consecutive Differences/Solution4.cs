using JetBrains.Annotations;

namespace LeetCode._0967_Numbers_With_Same_Consecutive_Differences;

/// <summary>
/// https://leetcode.com/submissions/detail/898776584/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int[] NumsSameConsecDiff(int n, int k) => Enumerate(n, k, -1).Select(FromDigits).ToArray();
    private static int FromDigits(IEnumerable<int> digits) => digits.Aggregate((a, b) => 10 * a + b);
    private static IEnumerable<IEnumerable<int>> Enumerate(int n, int k, int digit)
    {
        if (digit == -1)
        {
            for (var nextDigit = 0; nextDigit <= 9; nextDigit++)
            {
                foreach (var digits in Enumerate(n, k, nextDigit))
                {
                    yield return digits;
                }
            }

            yield break;
        }

        if (n == 1)
        {
            if (digit == 0)
            {
                yield break;
            }

            yield return new[] { digit };
            yield break;
        }

        foreach (var nextDigit in new[] { digit - k, digit + k }.Where(nextDigit => nextDigit is >= 0 and <= 9).Distinct())
        {
            foreach (var digits in Enumerate(n - 1, k, nextDigit))
            {
                yield return digits.Append(digit);
            }
        }
    }
}
