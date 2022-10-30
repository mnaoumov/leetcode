using JetBrains.Annotations;

namespace LeetCode._2457_Minimum_Addition_to_Make_Integer_Beautiful;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-317/submissions/detail/833081949/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MakeIntegerBeautiful(long n, int target)
    {
        var candidate = n;

        while (SumOfDigits(candidate) > target)
        {
            var tensPower = 1L;

            long lastDigit;

            while ((lastDigit = candidate % 10) == 0)
            {
                candidate /= 10;
                tensPower *= 10;
            }

            candidate -= lastDigit;
            candidate += 10;
            candidate *= tensPower;
        }

        return candidate - n;
    }

    private static int SumOfDigits(long number)
    {
        var result = 0;

        while (number > 0)
        {
            var digit = (int) (number % 10);
            number /= 10;
            result += digit;
        }

        return result;
    }
}
