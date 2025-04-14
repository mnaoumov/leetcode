using System.Numerics;

namespace LeetCode.Problems._2818_Apply_Operations_to_Maximize_Score;

/// <summary>
/// https://leetcode.com/problems/apply-operations-to-maximize-score/submissions/1590552647/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaximumScore(IList<int> nums, int k)
    {
        var n = nums.Count;
        var numArr = new int[n];
        var maxNum = int.MinValue;
        for (var i = 0; i < n; i++)
        {
            numArr[i] = nums[i];
            maxNum = int.Max(maxNum, nums[i]);
        }

        nums.CopyTo(numArr, 0);
        var primeScores = PrimeScoresSieve(maxNum);

        var left = new int[n];
        var right = new int[n];
        var stack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && primeScores[numArr[stack.Peek()]] < primeScores[numArr[i]])
            {
                stack.Pop();
            }

            left[i] = stack.Count == 0 ? i + 1 : i - stack.Peek();
            stack.Push(i);
        }

        stack.Clear();
        for (var i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && primeScores[numArr[stack.Peek()]] <= primeScores[numArr[i]])
            {
                stack.Pop();
            }

            right[i] = stack.Count == 0 ? n - i : stack.Peek() - i;
            stack.Push(i);
        }

        var freq = new long[n];
        for (var i = 0; i < n; i++)
        {
            freq[i] = (long) left[i] * right[i];
        }

        Array.Sort(numArr, freq, Comparer<int>.Create((a, b) => b.CompareTo(a)));
        var currentIndex = 0;
        var maximumScore = 1;
        const int modulus = 1_000_000_007;

        while (k > 0)
        {
            maximumScore = (int) ((long) maximumScore * (int) BigInteger.ModPow(numArr[currentIndex], long.Min(freq[currentIndex], k), modulus) %
                                  modulus);
            k -= (int) long.Min(freq[currentIndex], k);
            currentIndex++;
        }

        return maximumScore;

        int[] PrimeScoresSieve(int num)
        {
            var primeScores2 = new int[num + 1];

            for (var i = 2; i <= num; i++)
            {
                if (primeScores2[i] != 0)
                {
                    continue;
                }
                for (var j = i; j <= num; j += i)
                {
                    primeScores2[j]++;
                }
            }

            return primeScores2;
        }
    }
}
