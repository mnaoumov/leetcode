namespace LeetCode.Problems._3461_Check_If_Digits_Are_Equal_in_String_After_Operations_I;

/// <summary>
/// https://leetcode.com/problems/check-if-digits-are-equal-in-string-after-operations-i/submissions/1809889876/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasSameDigits(string s)
    {
        var digits = s.Select(c => c - '0').ToList();

        while (digits.Count > 2)
        {
            for (var i = 0; i < digits.Count - 1; i++)
            {
                digits[i] = (digits[i] + digits[i + 1]) % 10;
            }

            digits.RemoveAt(digits.Count - 1);
        }

        return digits[0] == digits[1];
    }
}
