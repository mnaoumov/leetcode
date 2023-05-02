using JetBrains.Annotations;

namespace LeetCode._0066_Plus_One;

/// <summary>
/// https://leetcode.com/problems/plus-one/submissions/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] PlusOne(int[] digits)
    {
        var result = new List<int>();

        var carry = true;

        foreach (var digit in digits.Reverse())
        {
            var resultDigit = digit + (carry ? 1 : 0);

            carry = resultDigit >= 10;

            if (carry)
            {
                resultDigit -= 10;
            }

            result.Insert(0, resultDigit);
        }

        if (carry)
        {
            result.Insert(0, 1);
        }

        return result.ToArray();
    }
}
