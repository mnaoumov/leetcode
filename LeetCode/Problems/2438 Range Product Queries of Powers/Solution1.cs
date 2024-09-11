
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2438_Range_Product_Queries_of_Powers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-89/submissions/detail/823017036/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ProductQueries(int n, int[][] queries)
    {
        var powers = new List<int>();
        var power = 1;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                powers.Add(power);
            }

            n /= 2;
            power *= 2;
        }

        const int modulo = 1000000007;

        return queries.Select(Calculate).ToArray();

        int Calculate(int[] query)
        {
            long result = 1;

            for (var i = query[0]; i <= query[1]; i++)
            {
                result = (result * powers[i]) % modulo;
            }

            return (int) result;
        }
    }
}
