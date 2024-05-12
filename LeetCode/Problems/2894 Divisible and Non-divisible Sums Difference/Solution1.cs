using JetBrains.Annotations;

namespace LeetCode._2894_Divisible_and_Non_divisible_Sums_Difference;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-366/submissions/detail/1069755298/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DifferenceOfSums(int n, int m)
    {
        var num1 = 0;
        var num2 = 0;

        for (var i = 1; i <= n; i++)
        {
            if (i % m != 0)
            {
                num1 += i;
            }
            else
            {
                num2 += i;
            }
        }

        return num1 - num2;
    }
}
