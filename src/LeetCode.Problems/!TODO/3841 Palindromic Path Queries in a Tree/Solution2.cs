using System.Globalization;

namespace LeetCode.Problems._3841_Palindromic_Path_Queries_in_a_Tree;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-176/problems/palindromic-path-queries-in-a-tree/submissions/1919157316/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
    {
        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var parents = new int[n];
        var assignedLetters = s.ToCharArray();
        const int rootParent = -1;

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjacentNodes[u].Add(v);
            adjacentNodes[v].Add(u);
        }

        parents[0] = rootParent;
        InitParents(0);

        var ans = new List<bool>();

        foreach (var query in queries)
        {
            var queryParts = query.Split(' ');

            switch (queryParts[0])
            {
                case "update":
                    {
                        var u = int.Parse(queryParts[1], CultureInfo.InvariantCulture);
                        var c = queryParts[2][0];
                        assignedLetters[u] = c;
                        break;
                    }
                case "query":
                    {
                        var u = int.Parse(queryParts[1], CultureInfo.InvariantCulture);
                        var v = int.Parse(queryParts[2], CultureInfo.InvariantCulture);

                        var uvPathMask = GetPathMask(u, v);
                        var canBePalindrome = BitCount(uvPathMask) <= 1;
                        ans.Add(canBePalindrome);
                        break;
                    }
            }
        }

        return ans;

        List<int> GetAncestors(int node)
        {
            var ans2 = new List<int>();
            while (node != rootParent)
            {
                ans2.Add(node);
                node = parents[node];
            }
            return ans2;
        }

        int GetNodeMask(int node)
        {
            var letterIndex = assignedLetters[node] - 'a';
            return 1 << letterIndex;
        }

        void InitParents(int node)
        {
            foreach (var adjNode in adjacentNodes[node].Where(adjNode => adjNode != parents[node]))
            {
                parents[adjNode] = node;
                InitParents(adjNode);
            }
        }

        int GetPathMask(int u, int v)
        {
            var uAncestors = GetAncestors(u);
            var vAncestors = GetAncestors(v);

            var i = 0;

            while (i < uAncestors.Count && i < vAncestors.Count && uAncestors[^(i + 1)] == vAncestors[^(i + 1)])
            {
                i++;
            }

            var ans2 = 0;

            for (var j = 0; j < uAncestors.Count + 1 - i; j++)
            {
                ans2 ^= GetNodeMask(uAncestors[j]);
            }

            for (var j = 0; j < vAncestors.Count - i; j++)
            {
                ans2 ^= GetNodeMask(vAncestors[j]);
            }

            return ans2;
        }
    }

    private static int BitCount(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            ans += num & 1;
            num >>= 1;
        }

        return ans;
    }
}
