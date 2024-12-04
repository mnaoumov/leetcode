using System.Text;

namespace LeetCode.Problems._2109_Adding_Spaces_to_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1468817188/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string AddSpaces(string s, int[] spaces)
    {
        var sb = new StringBuilder(s);

        for (var i = spaces.Length - 1; i >= 0; i--)
        {
            var index = spaces[i];
            sb.Insert(index, ' ');
        }

        return sb.ToString();
    }
}
