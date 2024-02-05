using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0293_Flip_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/1162656352/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> GeneratePossibleNextMoves(string currentState)
    {
        var sb = new StringBuilder(currentState);

        var ans = new List<string>();

        for (var i = 0; i < sb.Length - 1; i++)
        {
            if (sb[i] != '+' || sb[i + 1] != '+')
            {
                continue;
            }

            sb[i] = '-';
            sb[i + 1] = '-';
            ans.Add(sb.ToString());
            sb[i] = '+';
            sb[i + 1] = '+';
        }

        return ans;
    }
}
