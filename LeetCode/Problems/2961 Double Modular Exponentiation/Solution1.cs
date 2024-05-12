using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._2961_Double_Modular_Exponentiation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-375/submissions/detail/1116136266/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> GetGoodIndices(int[][] variables, int target)
    {
        var n = variables.Length;

        return Enumerable.Range(0, n).Where(IsGood).ToArray();

        bool IsGood(int index)
        {
            var a = variables[index][0];
            var b = variables[index][1];
            var c = variables[index][2];
            var m = variables[index][3];

            var x = BigInteger.ModPow(a, b, 10);
            var y = BigInteger.ModPow(x, c, m);
            return y == target;
        }
    }
}
