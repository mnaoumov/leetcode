using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._3559_Number_of_Ways_to_Assign_Edge_Weights_II;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-assign-edge-weights-ii/submissions/2030277005/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var n = edges.Length + 1;
        var adjNodes = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[u].Add(v);
            adjNodes[v].Add(u);
        }


        var pathsFromRoot = new List<int>[n + 1];
        pathsFromRoot[1] = new List<int>();

        var visited = new bool[n + 1];
        Dfs(1, 1);

        return queries.Select(query => Answer(query[0], query[1])).ToArray();

        void Dfs(int node, int parent)
        {
            visited[node] = true;
            pathsFromRoot[node] = pathsFromRoot[parent].ToList();
            pathsFromRoot[node].Add(node);

            foreach (var adjNode in adjNodes[node].Where(adjNode => !visited[adjNode]))
            {
                Dfs(adjNode, node);
            }
        }

        int Answer(int u, int v)
        {
            if (u == v)
            {
                return 0;
            }

            var i = 0;

            while (i < pathsFromRoot[u].Count && i < pathsFromRoot[v].Count && pathsFromRoot[u][i] == pathsFromRoot[v][i])
            {
                i++;
            }

            var length = pathsFromRoot[u].Count + pathsFromRoot[v].Count - 2 * i;
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
