using JetBrains.Annotations;

namespace LeetCode._2652_Sum_Multiples;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-342/submissions/detail/938157873/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfMultiples(int n)
    {
        var ans = 0;

        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
            {
                ans += i;
            }
        }

        return ans;
    }
}
