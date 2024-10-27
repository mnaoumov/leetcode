namespace LeetCode.Problems._100430_Find_Subtree_Sizes_After_Changes;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-142/submissions/detail/1434320720/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindSubtreeSizes(int[] parent, string s)
    {
        var n = s.Length;
        var ans = new int[n];
        const int noParent = -1;

        var descendants = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 1; i < n; i++)
        {
            var p = parent[i];
            while (p != noParent && s[p] != s[i])
            {
                p = parent[p];
            }

            if (p == noParent)
            {
                p = parent[i];
            }

            descendants[p].Add(i);
        }

        Dfs(0);

        return ans;

        int Dfs(int node)
        {
            ans[node] = 1;
            foreach (var child in descendants[node])
            {
                ans[node] += Dfs(child);
            }

            return ans[node];
        }
    }
}
