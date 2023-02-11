using JetBrains.Annotations;

namespace LeetCode._2553_Separate_the_Digits_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-97/submissions/detail/891331172/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SeparateDigits(int[] nums) => nums.SelectMany(GetDigits).ToArray();

    private static IEnumerable<int> GetDigits(int num)
    {
        var digits = new List<int>();

        while (num > 0)
        {
            var digit = num % 10;
            digits.Insert(0, digit);
            num /= 10;
        }

        return digits;
    }
}
