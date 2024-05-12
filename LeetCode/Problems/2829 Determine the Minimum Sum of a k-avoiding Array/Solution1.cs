using JetBrains.Annotations;

namespace LeetCode.Problems._2829_Determine_the_Minimum_Sum_of_a_k_avoiding_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-359/submissions/detail/1026275507/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSum(int n, int k)
    {
        var ans = 0;
        var nums = new HashSet<int>();
        var min = 1;

        for (var i = 0; i < n; i++)
        {
            nums.Add(min);
            ans += min;
            min++;

            while (nums.Contains(k - min))
            {
                min++;
            }
        }

        return ans;
    }
}
