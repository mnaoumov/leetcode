using System.Text;

namespace LeetCode.Problems._1963_Minimum_Number_of_Swaps_to_Make_the_String_Balanced;

/// <summary>
/// https://leetcode.com/submissions/detail/1415330247/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSwaps(string s)
    {
        var sb = new StringBuilder(s);
        const char open = '[';
        const char close = ']';
        var j = s.Length - 1;
        var ans = 0;
        var balance = 0;
        for (var i = 0; i < sb.Length; i++)
        {
            var isOpen = sb[i] == open;
            balance += isOpen ? 1 : -1;

            if (balance != -1)
            {
                continue;
            }

            balance = 1;
            sb[i] = open;
            while (sb[j] == close)
            {
                j--;
            }

            sb[j] = close;
            ans++;
        }

        return ans;
    }
}