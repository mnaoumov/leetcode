using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._3266_Final_Array_State_After_K_Multiplication_Operations_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-412/submissions/detail/1367377298/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    private const int Modulus = 1_000_000_007;

    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        if (multiplier == 1)
        {
            return nums;
        }

        var n = nums.Length;

        var set = new SortedSet<(BigInteger num, int index)>();


        if (n == 0)
        {
            throw new ArgumentException("n == 0");
        }

        for (var i = 0; i < n; i++)
        {
            set.Add((nums[i], i));
        }

        var ans = new int[n];

        for (var i = 0; i < k; i++)
        {
            var min = set.Min.num;
            var max = set.Max.num;
            if (min * multiplier > max)
            {
                var m = (k - i) / n;
                var r = (k - i) % n;

                var j = 0;

                foreach (var (num2, index2) in set.ToArray())
                {
                    var num3 = (int) (num2 * BigInteger.ModPow(multiplier, m + (j < r ? 1 : 0), Modulus) % Modulus);
                    set.Remove((num2, index2));
                    set.Add((num3, index2));
                    j++;
                }

                break;
            }

            var (num, index) = set.Min;
            set.Remove(set.Min);
            set.Add((num * multiplier, index));
        }

        foreach (var (num,index) in set)
        {
            ans[index] = (int) (num % Modulus);
        }

        return ans;

    }
}
