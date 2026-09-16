using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._3559_Number_of_Ways_to_Assign_Edge_Weights_II;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-assign-edge-weights-ii/submissions/2030289678/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var n = edges.Length + 1;
        var adjNodes = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();
        var parents = new int[n + 1];
        var depths = new int[n + 1];

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[u].Add(v);
            adjNodes[v].Add(u);
        }


        var visited = new bool[n + 1];
        Dfs(1, 0, 0);

        return queries.Select(query => Answer(query[0], query[1])).ToArray();

        void Dfs(int node, int parent, int depth)
        {
            visited[node] = true;
            parents[node] = parent;
            depths[node] = depth;

            foreach (var adjNode in adjNodes[node].Where(adjNode => !visited[adjNode]))
            {
                Dfs(adjNode, node, depth + 1);
            }
        }

        int Answer(int u, int v)
        {
            if (u == v)
            {
                return 0;
            }

            var length = depths[u] + depths[v];

            if (depths[u] < depths[v])
            {
                (u, v) = (v, u);
            }

            while (depths[u] > depths[v])
            {
                u = parents[u];
            }

            while (u != v)
            {
                u = parents[u];
                v = parents[v];
            }

            length -= 2 * depths[u];
            return ModNumber.Pow(2, length - 1);
        }
    }

    private sealed class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
