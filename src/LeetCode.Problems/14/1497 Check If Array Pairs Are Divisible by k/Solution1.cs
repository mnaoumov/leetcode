namespace LeetCode.Problems._1497_Check_If_Array_Pairs_Are_Divisible_by_k;

/// <summary>
/// https://leetcode.com/submissions/detail/1407687309/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanArrange(int[] arr, int k)
    {
        var remainderCounts = new int[k];
        foreach (var num in arr)
        {
            var remainder = num % k;
            if (remainder < 0)
            {
                remainder += k;
            }

            remainderCounts[remainder]++;
        }

        if (remainderCounts[0] % 2 != 0)
        {
            return false;
        }

        for (var i = 1; i <= k / 2; i++)
        {
            if (remainderCounts[i] != remainderCounts[k - i])
            {
                return false;
            }
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (k % 2 == 0 && remainderCounts[k / 2] % 2 != 0)
        {
            return false;
        }

        return true;
    }
}
