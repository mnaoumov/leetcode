using System.Numerics;

namespace LeetCode.Problems._0679_24_Game;

/// <summary>
/// https://leetcode.com/problems/24-game/submissions/1739189289/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool JudgePoint24(int[] cards)
    {
        var fractions = cards.Select(card => (Fraction) card).ToArray();

        var permutations = new List<Fraction[]>();
        var permutation = new List<Fraction>();
        var usedIndices = new HashSet<int>();
        Backtrack();

        return permutations.Any(p => GetAllPossibleValues(p).Contains(24));

        void Backtrack()
        {
            if (usedIndices.Count == fractions.Length)
            {
                permutations.Add(permutation.ToArray());
                return;
            }

            for (var i = 0; i < fractions.Length; i++)
            {
                if (usedIndices.Contains(i))
                {
                    continue;
                }

                permutation.Add(fractions[i]);
                usedIndices.Add(i);
                Backtrack();
                usedIndices.Remove(i);
                permutation.RemoveAt(permutation.Count - 1);
            }
        }
    }

    private static HashSet<Fraction> GetAllPossibleValues(Fraction[] fractions)
    {
        var n = fractions.Length;

        if (n == 1)
        {
            return fractions.ToHashSet();
        }

        var ans = new HashSet<Fraction>();

        for (var i = 1; i < n; i++)
        {
            var nums1 = fractions.Take(i).ToArray();
            var nums2 = fractions.Skip(i).ToArray();

            var values1 = GetAllPossibleValues(nums1);
            var values2 = GetAllPossibleValues(nums2);

            foreach (var value1 in values1)
            {
                foreach (var value2 in values2)
                {
                    ans.Add(value1 + value2);
                    ans.Add(value1 - value2);
                    ans.Add(value1 * value2);

                    if (value2 != 0)
                    {
                        ans.Add(value1 / value2);
                    }
                }
            }
        }

        return ans;
    }

    private class Fraction : IEquatable<Fraction>
    {
        private Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            Numerator = numerator / (int) gcd;
            Denominator = denominator / (int) gcd;

            if (Denominator > 0)
            {
                return;
            }

            Numerator = -Numerator;
            Denominator = -Denominator;
        }

        private int Denominator { get; }
        private int Numerator { get; }

        public static implicit operator Fraction(int value) => new(value, 1);

        public static Fraction operator +(Fraction left, Fraction right) =>
            new(left.Numerator * right.Denominator + right.Numerator * left.Denominator,
                left.Denominator * right.Denominator);

        public static Fraction operator -(Fraction left, Fraction right) => new(
            left.Numerator * right.Denominator - right.Numerator * left.Denominator,
            left.Denominator * right.Denominator);

        public static Fraction operator *(Fraction left, Fraction right) => new(
            left.Numerator * right.Numerator, left.Denominator * right.Denominator);

        public static Fraction operator /(Fraction left, Fraction right) => new(
            left.Numerator * right.Denominator, left.Denominator * right.Numerator);

        public static bool operator ==(Fraction left, Fraction right) => Equals(left, right);

        public static bool operator !=(Fraction left, Fraction right) => !Equals(left, right);

        public bool Equals(Fraction? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Denominator == other.Denominator && Numerator == other.Numerator;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Fraction) obj);
        }

        public override int GetHashCode() => HashCode.Combine(Denominator, Numerator);
    }
}
