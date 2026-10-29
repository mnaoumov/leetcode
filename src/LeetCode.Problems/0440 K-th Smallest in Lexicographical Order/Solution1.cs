namespace LeetCode.Problems._0440_K_th_Smallest_in_Lexicographical_Order;

/// <summary>
/// https://leetcode.com/submissions/detail/1398766246/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindKthNumber(int n, int k)
    {
        var num = 1;
        k--;

        while (k > 0)
        {
            var steps = CalculateSteps(n, num, num + 1);
            if (steps <= k)
            {
                num++;
                k -= steps;
            }
            else
            {
                num *= 10;
                k--;
            }
        }

        return num;
    }

    private static int CalculateSteps(int n, long prefix1, long prefix2)
    {
        var steps = 0;

        while (prefix1 <= n)
        {
            steps += (int) (Math.Min(n + 1, prefix2) - prefix1);
            prefix1 *= 10;
            prefix2 *= 10;
        }

        return steps;
    }
}
