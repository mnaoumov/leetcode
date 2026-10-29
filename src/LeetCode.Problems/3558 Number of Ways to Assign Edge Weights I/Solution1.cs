using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._3558_Number_of_Ways_to_Assign_Edge_Weights_I;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-assign-edge-weights-i/submissions/2029163188/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AssignEdgeWeights(int[][] edges)
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

        var visited = new bool[n + 1];
        var maxDepth = Dfs(1, 0);

        return ModNumber.Pow(2, maxDepth - 1);

        int Dfs(int node, int depth)
        {
            visited[node] = true;
            return adjNodes[node].Where(adjNode => !visited[adjNode]).Select(adjNode => Dfs(adjNode, depth + 1)).Prepend(depth).Max();
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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
