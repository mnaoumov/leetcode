namespace LeetCode.Problems._3765_Complete_Prime_Number;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-171/problems/complete-prime-number/submissions/1848395804/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private readonly Dictionary<int, bool> _isPrimeCache = new();

    public bool CompletePrime(int num)
    {
        var str = num.ToString();
        var n = str.Length;

        var prefix = 0;
        var suffix = 0;
        var suffixMultiplier = 1;

        for (var i = 0; i < n; i++)
        {
            prefix = 10 * prefix + (str[i] - '0');
            suffix += (str[n - 1 - i] - '0') * suffixMultiplier;
            suffixMultiplier *= 10;

            if (!IsPrime(prefix) || !IsPrime(suffix))
            {
                return false;
            }
        }

        return true;
    }

    private bool IsPrime(int num)
    {
        if (_isPrimeCache.TryGetValue(num, out var ans))
        {
            return ans;
        }

        if (num < 2)
        {
            _isPrimeCache[num] = false;
            return false;
        }

        for (var i = 2; i * i <= num; i++)
        {
            if (num % i != 0)
            {
                continue;
            }

            _isPrimeCache[num] = false;
            return false;
        }

        _isPrimeCache[num] = true;
        return true;
    }
}
