// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class GcdTemplate
{
    /// <summary>Non-negative; Gcd(0, 0) = 0.</summary>
    public static long Gcd(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }

    /// <summary>Non-negative; 0 when either is 0. Divides before multiplying, so it overflows only when the result does.</summary>
    public static long Lcm(long a, long b) => a == 0 || b == 0 ? 0 : Math.Abs(a / Gcd(a, b) * b);

    public static long Gcd(IEnumerable<long> numbers) => numbers.Aggregate(0L, Gcd);

    public static long Lcm(IEnumerable<long> numbers) => numbers.Aggregate(1L, Lcm);

    /// <summary>The digits of a non-negative n, most significant first; [0] for 0.</summary>
    public static List<int> Digits(long n)
    {
        var digits = new List<int>();

        do
        {
            digits.Add((int) (n % 10));
            n /= 10;
        } while (n > 0);

        digits.Reverse();
        return digits;
    }

    public static long FromDigits(IEnumerable<int> digits) => digits.Aggregate(0L, (number, digit) => number * 10 + digit);
}
