using System.Globalization;

namespace LeetCode.Problems._3918_Sum_of_Primes_Between_Number_and_Its_Reverse;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-500/problems/sum-of-primes-between-number-and-its-reverse/submissions/1993780901/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfPrimesInRange(int n)
    {
        var r = int.Parse(string.Concat(n.ToString(CultureInfo.InvariantCulture).Reverse()),
            CultureInfo.InvariantCulture);

        var min = Math.Min(n, r);
        var max = Math.Max(n, r);

        var primes = new SortedSet<int>();

        for (var i = 2; i <= max; i++)
        {
            var maxPrime = Math.Floor(Math.Sqrt(i));
            var isPrime = primes.TakeWhile(p => p <= maxPrime).All(p => i % p != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }


        return primes.GetViewBetween(min, max).Sum();
    }
}
