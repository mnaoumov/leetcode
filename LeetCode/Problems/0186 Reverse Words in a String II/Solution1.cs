using JetBrains.Annotations;

namespace LeetCode.Problems._0186_Reverse_Words_in_a_String_II;

/// <summary>
/// https://leetcode.com/submissions/detail/901778349/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void ReverseWords(char[] s)
    {
        Reverse(0, s.Length - 1);

        var left = 0;

        while (left < s.Length)
        {
            var right = left;

            while (right < s.Length && s[right] != ' ')
            {
                right++;
            }

            Reverse(left, right - 1);

            left = right + 1;
        }

        return;

        void Reverse(int left2, int right2)
        {
            while (left2 < right2)
            {
                (s[left2], s[right2]) = (s[right2], s[left2]);
                left2++;
                right2--;
            }
        }
    }
}
