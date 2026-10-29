using System.Text;

namespace LeetCode.Problems._3327_Check_if_DFS_Strings_Are_Palindromes;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-420/submissions/detail/1427955066/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool[] FindAnswer(int[] parent, string s)
    {
        var n = parent.Length;
        var children = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var node = 0; node < n; node++)
        {
            var p = parent[node];
            if (p != -1)
            {
                children[p].Add(node);
            }
        }

        var ans = new bool[n];

        Dfs(0);

        return ans;

        string Dfs(int node)
        {
            var sb = new StringBuilder();

            foreach (var child in children[node])
            {
                sb.Append(Dfs(child));
            }

            sb.Append(s[node]);

            ans[node] = true;

            for (var i = 0; i < sb.Length / 2; i++)
            {
                if (sb[i] == sb[sb.Length - 1 - i])
                {
                    continue;
                }

                ans[node] = false;
                break;
            }

            return sb.ToString();
        }
    }
}
