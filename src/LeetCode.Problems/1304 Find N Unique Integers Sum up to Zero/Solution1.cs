namespace LeetCode.Problems._1304_Find_N_Unique_Integers_Sum_up_to_Zero;

/// <summary>
/// https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/submissions/1762011086/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SumZero(int n)
    {
        var list = new List<int>();
        for (var i = 1; i <= n / 2; i++)
        {
            list.Add(i);
            list.Add(-i);
        }

        if (n % 2 != 0)
        {
            list.Add(0);
        }

        return list.ToArray();
    }
}
