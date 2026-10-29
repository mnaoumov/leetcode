namespace LeetCode.Problems._3343_Count_Number_of_Balanced_Permutations;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    private const long Mod = 1_000_000_007;

    public int CountBalancedPermutations(string num)
    {
        var sum = 0;
        var n = num.Length;
        var digitCounts = new int[10];

        foreach (var digit in num.Select(ch => ch - '0'))
        {
            digitCounts[digit]++;
            sum += digit;
        }

        if (sum % 2 != 0)
        {
            return 0;
        }

        var target = sum / 2;
        var maxOdd = (n + 1) / 2;
        var chooseCache = new long[maxOdd + 1, maxOdd + 1];
        var dp = new long[target + 1, maxOdd + 1];

        for (var i = 0; i <= maxOdd; i++)
        {
            chooseCache[i, i] = chooseCache[i, 0] = 1;
            for (var j = 1; j < i; j++)
            {
                chooseCache[i, j] = (chooseCache[i - 1, j] + chooseCache[i - 1, j - 1]) % Mod;
            }
        }

        dp[0, 0] = 1;
        var usedCounts = 0;
        var usedSum = 0;
        for (var digit = 0; digit <= 9; digit++)
        {
            usedCounts += digitCounts[digit];
            usedSum += digit * digitCounts[digit];
            for (var oddCount = Math.Min(usedCounts, maxOdd);
                 oddCount >= Math.Max(0, usedCounts - (n - maxOdd)); oddCount--)
            {
                var evenCount = usedCounts - oddCount;
                for (var curr = Math.Min(usedSum, target); curr >= Math.Max(0, usedSum - target); curr--)
                {
                    long res = 0;
                    for (var j = Math.Max(0, digitCounts[digit] - evenCount);
                         j <= Math.Min(digitCounts[digit], oddCount) && digit * j <= curr; j++)
                    {
                        var ways =
                            chooseCache[oddCount, j] * chooseCache[evenCount, digitCounts[digit] - j] % Mod;
                        res = (res + ways * dp[curr - digit * j, oddCount - j] % Mod) %
                              Mod;
                    }
                    dp[curr, oddCount] = res % Mod;
                }
            }
        }

        return (int) dp[target, maxOdd];
    }
}
