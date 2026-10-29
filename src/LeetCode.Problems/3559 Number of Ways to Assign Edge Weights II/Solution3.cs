using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._3559_Number_of_Ways_to_Assign_Edge_Weights_II;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-assign-edge-weights-ii/submissions/2036914062/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        var n = edges.Length + 1;

        var adjStart = new int[n + 2];
        foreach (var edge in edges)
        {
            adjStart[edge[0] + 1]++;
            adjStart[edge[1] + 1]++;
        }

        for (var node = 1; node <= n + 1; node++)
        {
            adjStart[node] += adjStart[node - 1];
        }

        var adjNodes = new int[2 * edges.Length];
        var fill = (int[]) adjStart.Clone();
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[fill[u]++] = v;
            adjNodes[fill[v]++] = u;
        }

        var maxLevel = 1;
        while (1 << maxLevel < n)
        {
            maxLevel++;
        }

        var ancestors = new int[maxLevel + 1][];
        for (var level = 0; level <= maxLevel; level++)
        {
            ancestors[level] = new int[n + 1];
        }

        var parents = ancestors[0];
        var depths = new int[n + 1];

        var order = new int[n];
        var visited = new bool[n + 1];
        var head = 0;
        var tail = 0;
        order[tail] = 1;
        tail++;
        visited[1] = true;

        while (head < tail)
        {
            var node = order[head];
            head++;
            for (var i = adjStart[node]; i < adjStart[node + 1]; i++)
            {
                var adjNode = adjNodes[i];
                if (visited[adjNode])
                {
                    continue;
                }

                visited[adjNode] = true;
                parents[adjNode] = node;
                depths[adjNode] = depths[node] + 1;
                order[tail++] = adjNode;
            }
        }

        for (var level = 1; level <= maxLevel; level++)
        {
            var current = ancestors[level];
            var previous = ancestors[level - 1];
            for (var node = 1; node <= n; node++)
            {
                current[node] = previous[previous[node]];
            }
        }

        var pow2 = new int[n];
        pow2[0] = 1;
        for (var i = 1; i < n; i++)
        {
            pow2[i] = (ModNumber) pow2[i - 1] * 2;
        }

        return queries.Select(query => Answer(query[0], query[1])).ToArray();

        int Answer(int u, int v)
        {
            if (u == v)
            {
                return 0;
            }

            var length = depths[u] + depths[v] - 2 * depths[LeastCommonAncestor(u, v)];
            return pow2[length - 1];
        }

        int LeastCommonAncestor(int u, int v)
        {
            if (depths[u] < depths[v])
            {
                (u, v) = (v, u);
            }

            var diff = depths[u] - depths[v];
            for (var level = 0; diff > 0; level++, diff >>= 1)
            {
                if ((diff & 1) == 1)
                {
                    u = ancestors[level][u];
                }
            }

            if (u == v)
            {
                return u;
            }

            for (var level = maxLevel; level >= 0; level--)
            {
                if (ancestors[level][u] == ancestors[level][v])
                {
                    continue;
                }

                u = ancestors[level][u];
                v = ancestors[level][v];
            }

            return parents[u];
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

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
