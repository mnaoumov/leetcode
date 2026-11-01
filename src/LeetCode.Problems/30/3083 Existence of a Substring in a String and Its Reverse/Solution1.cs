namespace LeetCode.Problems._3083_Existence_of_a_Substring_in_a_String_and_Its_Reverse;

/// <seealso href="https://leetcode.com/contest/weekly-contest-389/submissions/detail/1205836264/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsSubstringPresent(string s)
    {
        var reverse = string.Concat(s.Reverse());

        for (var i = 0; i < s.Length - 1; i++)
        {
            var substring = s[i..(i + 2)];

            if (reverse.Contains(substring))
            {
                return true;
            }
        }

        return false;
    }
}
