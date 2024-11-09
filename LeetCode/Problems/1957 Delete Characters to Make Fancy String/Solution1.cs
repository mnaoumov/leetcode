using System.Text;

namespace LeetCode.Problems._1957_Delete_Characters_to_Make_Fancy_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1439435417/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string MakeFancyString(string s)
    {
        var sb = new StringBuilder(s);
        for (var i = 2; i < sb.Length; i++)
        {
            if (sb[i] != sb[i - 1] || sb[i] != sb[i - 2])
            {
                continue;
            }

            sb.Remove(i, 1);
            i--;
        }

        return sb.ToString();
    }
}
