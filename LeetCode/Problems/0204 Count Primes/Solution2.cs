namespace LeetCode.Problems._0204_Count_Primes;

/// <summary>
/// https://leetcode.com/submissions/detail/923274587/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountPrimes(int n)
    {
        if (n < 2)
        {
            return 0;
        }

        var isPrimeArr = Enumerable.Range(0, n).Select(_ => true).ToArray();

        isPrimeArr[0] = false;
        isPrimeArr[1] = false;

        for (var i = 2; i < (n + 1) / 2; i++)
        {
            if (!isPrimeArr[i])
            {
                continue;
            }

            for (var j = 2 * i; j < n; j += i)
            {
                isPrimeArr[j] = false;
            }
        }

        return isPrimeArr.Count(x => x);
    }
}
