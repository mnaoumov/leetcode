namespace LeetCode.Problems._3438_Find_Valid_Pair_of_Adjacent_Digits_in_String;

/// <summary>
/// https://leetcode.com/problems/find-valid-pair-of-adjacent-digits-in-string/submissions/1527520929/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FindValidPair(string s)
    {
        var counts = s.GroupBy(digit => digit - '0').ToDictionary(g => g.Key, g => g.Count());

        for (var i = 0; i < s.Length - 1; i++)
        {
            var digit = s[i] - '0';
            var nextDigit = s[i + 1] - '0';

            if (digit == nextDigit)
            {
                continue;
            }

            if (counts[digit] != digit || counts[nextDigit] != nextDigit)
            {
                continue;
            }

            return $"{digit}{nextDigit}";
        }

        return "";
    }
}
