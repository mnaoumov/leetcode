namespace LeetCode.Problems._2999_Count_the_Number_of_Powerful_Integers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-121/submissions/detail/1138603032/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        var dp = new Dictionary<string, long>();

        return NumberOfPowerfulInt2(finish.ToString()) - NumberOfPowerfulInt2((start - 1).ToString());

        long NumberOfPowerfulInt2(string maxStr)
        {
            if (maxStr.Length < s.Length || maxStr.Length == s.Length && string.Compare(maxStr, s, StringComparison.Ordinal) < 0)
            {
                return 0;
            }

            if (maxStr.Length == s.Length)
            {
                return 1;
            }

            if (dp.TryGetValue(maxStr, out var ans))
            {
                return ans;
            }

            dp[maxStr] = 0;

            var maxFirstDigit = maxStr[0] - '0';
            var allNines = new string('9', maxStr.Length - 1);

            for (var firstDigit = 0; firstDigit <= Math.Min(limit, maxFirstDigit); firstDigit++)
            {
                dp[maxStr] += firstDigit != maxFirstDigit
                    ? NumberOfPowerfulInt2(allNines)
                    : NumberOfPowerfulInt2(maxStr[1..]);
            }

            return dp[maxStr];
        }
    }
}
