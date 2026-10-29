namespace LeetCode.Problems._2977_Minimum_Cost_to_Convert_String_II;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-to-convert-string-ii/submissions/1901473118/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    private const int Infinity = int.MaxValue / 2;

    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        var n = source.Length;
        var m = original.Length;
        var root = new Trie();

        var p = -1;
        var costs = new int[m * 2, m * 2];

        for (var i = 0; i < m * 2; i++)
        {
            for (var j = 0; j < m * 2; j++)
            {
                costs[i, j] = Infinity;
            }
            costs[i, i] = 0;
        }

        for (var i = 0; i < m; i++)
        {
            var x = Add(root, original[i], ref p);
            var y = Add(root, changed[i], ref p);
            costs[x, y] = Math.Min(costs[x, y], cost[i]);
        }

        var size = p + 1;
        for (var k = 0; k < size; k++)
        {
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    costs[i, j] = Math.Min(costs[i, j], costs[i, k] + costs[k, j]);
                }
            }
        }

        var f = new long[n];
        Array.Fill(f, -1);
        for (var j = 0; j < n; j++)
        {
            if (j > 0 && f[j - 1] == -1)
            {
                continue;
            }
            var baseVal = (j == 0 ? 0 : f[j - 1]);
            if (source[j] == target[j])
            {
                Update(ref f[j], baseVal);
            }

            var u = root;
            var v = root;
            for (var i = j; i < n; i++)
            {
                u = u.Children[source[i] - 'a'];
                v = v.Children[target[i] - 'a'];
                if (u == null || v == null)
                {
                    break;
                }

                if (u.Id == -1 || v.Id == -1 || costs[u.Id, v.Id] == Infinity)
                {
                    continue;
                }

                var newVal = baseVal + costs[u.Id, v.Id];
                Update(ref f[i], newVal);
            }
        }

        return f[n - 1];
    }

    private static int Add(Trie node, string word, ref int index)
    {
        foreach (var ch in word)
        {
            var i = ch - 'a';

            var nextNode = node.Children[i] ??= new Trie();
            node.Children[i] = nextNode;
            node = nextNode;
        }
        if (node.Id == -1)
        {
            node.Id = ++index;
        }
        return node.Id;
    }

    private static void Update(ref long x, long y)
    {
        if (x == -1 || y < x)
        {
            x = y;
        }
    }

    public class Trie
    {
        public readonly Trie?[] Children = new Trie?[26];
        public int Id = -1;
    }
}