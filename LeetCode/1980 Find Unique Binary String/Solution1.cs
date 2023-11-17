using System.Text;
using JetBrains.Annotations;

namespace LeetCode._1980_Find_Unique_Binary_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1100421396/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        var set = nums.ToHashSet();
        var n = nums.Length;
        var digits = new[] { '0', '1' };

        var sb = new StringBuilder();
        return Backtrack()!;

        string? Backtrack()
        {
            if (sb.Length == n)
            {
                var str = sb.ToString();
                return set.Contains(str) ? null : str;
            }

            foreach (var digit in digits)
            {
                sb.Append(digit);
                var ans = Backtrack();

                if (ans != null)
                {
                    return ans;
                }
                sb.Remove(sb.Length - 1, 1);
            }

            return null;
        }
    }
}
