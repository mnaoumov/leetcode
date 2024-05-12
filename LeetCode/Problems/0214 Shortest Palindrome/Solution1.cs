using JetBrains.Annotations;

namespace LeetCode.Problems._0214_Shortest_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/946111164/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ShortestPalindrome(string s)
    {
        var direct = s.ToList();
        var reversed = s.ToList();
        reversed.Reverse();

        var index = 0;

        while (true)
        {
            var isPalindrome = true;

            for (var i = index; i < direct.Count; i++)
            {
                if (direct[i] == reversed[i])
                {
                    continue;
                }

                isPalindrome = false;
                direct.Insert(index, reversed[index]);
                reversed.Insert(reversed.Count - index, reversed[index]);
                break;
            }

            if (isPalindrome)
            {
                return string.Concat(direct);
            }

            index++;
        }
    }
}
