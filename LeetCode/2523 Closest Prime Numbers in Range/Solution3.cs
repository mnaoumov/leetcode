using JetBrains.Annotations;

namespace LeetCode._2523_Closest_Prime_Numbers_in_Range;

/// <summary>
/// https://leetcode.com/submissions/detail/869900787/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] ClosestPrimes(int left, int right)
    {
        var primeCandidates = Enumerable.Range(left, right - left + 1).ToHashSet();
        primeCandidates.Remove(1);

        for (var i = 2; i <= Math.Sqrt(right); i++)
        {
            for (var nonPrime = Math.Max(2, (int) Math.Ceiling((double) left / i)) * i; nonPrime <= right; nonPrime += i)
            {
                primeCandidates.Remove(nonPrime);
            }
        }

        if (primeCandidates.Count < 2)
        {
            return new[] { -1, -1 };
        }

        var sortedPrimes = primeCandidates.OrderBy(x => x).ToArray();

        var minDistance = int.MaxValue;
        var result = new int[2];

        for (var i = 0; i < sortedPrimes.Length - 1; i++)
        {
            var distance = sortedPrimes[i + 1] - sortedPrimes[i];

            if (distance >= minDistance)
            {
                continue;
            }

            minDistance = distance;
            result[0] = sortedPrimes[i];
            result[1] = sortedPrimes[i + 1];
        }

        return result;
    }
}
