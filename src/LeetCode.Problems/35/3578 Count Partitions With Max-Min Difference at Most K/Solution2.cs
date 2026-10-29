using System.Numerics;

namespace LeetCode.Problems._3578_Count_Partitions_With_Max_Min_Difference_at_Most_K;

/// <summary>
/// https://leetcode.com/problems/count-partitions-with-max-min-difference-at-most-k/submissions/1847998717/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountPartitions(int[] nums, int k)
    {
        var n = nums.Length;
        var dp = new ModNumber[n + 1];
        var prefix = new ModNumber[n + 1];
        var minQ = new LinkedList<int>();
        var maxQ = new LinkedList<int>();

        dp[0] = 1;
        prefix[0] = 1;
        var j = 0;
        for (var i = 0; i < n; i++)
        {
            while (maxQ.Last != null && nums[maxQ.Last.Value] <= nums[i])
            {
                maxQ.RemoveLast();
            }
            maxQ.AddLast(i);

            while (minQ.Last != null && nums[minQ.Last.Value] >= nums[i])
            {
                minQ.RemoveLast();
            }
            minQ.AddLast(i);

            while (maxQ.First != null && minQ.First != null && nums[maxQ.First.Value] - nums[minQ.First.Value] > k)
            {
                if (maxQ.First.Value == j)
                {
                    maxQ.RemoveFirst();
                }
                if (minQ.First.Value == j)
                {
                    minQ.RemoveFirst();
                }
                j++;
            }

            dp[i + 1] = prefix[i] - (j > 0 ? prefix[j - 1] : 0);
            prefix[i + 1] = prefix[i] + dp[i + 1];
        }

        return dp[n];
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}