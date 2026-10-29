namespace LeetCode.Problems._2221_Find_Triangular_Sum_of_an_Array;

/// <summary>
/// https://leetcode.com/problems/find-triangular-sum-of-an-array/submissions/1786923415/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TriangularSum(int[] nums)
    {
        var list = nums.ToList();

        while (list.Count > 1)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                list[i] = (list[i] + list[i + 1]) % 10;
            }

            list.RemoveAt(list.Count - 1);
        }

        return list[0];
    }
}