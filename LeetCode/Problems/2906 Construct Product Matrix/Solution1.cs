using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2906_Construct_Product_Matrix;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-367/submissions/detail/1075519243/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        var n = grid.Length;
        var m = grid[0].Length;

        var factors = new Factor[n, m];

        var ans = Enumerable.Range(0, n).Select(_ => new int[m]).ToArray();

        var productFactor = new Factor { OtherFactors = 1 };

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                var num = grid[i][j] % Factor.Modulo;

                if (num == 0)
                {
                    num = Factor.Modulo;
                }

                var factor = new Factor();

                while (num % 3 == 0)
                {
                    num /= 3;
                    factor.Power3++;
                }

                while (num % 5 == 0)
                {
                    num /= 5;
                    factor.Power5++;
                }

                while (num % 823 == 0)
                {
                    num /= 823;
                    factor.Power823++;
                }

                factor.OtherFactors = num;
                factors[i, j] = factor;

                productFactor.Power3 += factor.Power3;
                productFactor.Power5 += factor.Power5;
                productFactor.Power823 += factor.Power823;
                productFactor.OtherFactors = productFactor.OtherFactors * factor.OtherFactors % Factor.Modulo;
            }
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                var factor = factors[i, j];
                var restProductFactor = new Factor
                {
                    Power3 = productFactor.Power3 - factor.Power3,
                    Power5 = productFactor.Power5 - factor.Power5,
                    Power823 = productFactor.Power823 - factor.Power823
                };

                if (restProductFactor is { Power3: > 0, Power5: > 0, Power823: > 0 })
                {
                    ans[i][j] = 0;
                }
                else
                {
                    var inverse = (int) BigInteger.ModPow(factor.OtherFactors, Factor.PhiOfModulo - 1, Factor.Modulo);
                    restProductFactor.OtherFactors = productFactor.OtherFactors * inverse % Factor.Modulo;
                    ans[i][j] = restProductFactor.Multiply();
                }
            }
        }

        return ans;
    }

    private class Factor
    {
        public const int Modulo = 12345;
        public const int PhiOfModulo = (3 - 1) * (5 - 1) * (823 - 1);

        public int Power3 { get; set; }
        public int Power5 { get; set; }
        public int Power823 { get; set; }
        public int OtherFactors { get; set; }

        public int Multiply()
        {
            var factors = new[]
            {
                (int) BigInteger.ModPow(3, Power3, Modulo),
                (int) BigInteger.ModPow(5, Power5, Modulo),
                (int) BigInteger.ModPow(823, Power823, Modulo),
                OtherFactors
            };

            return factors.Aggregate((x, y) => x * y % Modulo);
        }
    }
}
