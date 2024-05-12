using JetBrains.Annotations;

namespace LeetCode.Problems._0448_Find_All_Numbers_Disappeared_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/924357635/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var n = nums.Length;
        var result = Enumerable.Range(1, n).ToList();

        foreach (var num in nums)
        {
            result[num - 1] = 0;
        }

        var j = 0;
        var length = 0;

        for (var i = 0; i < n; i++)
        {
            if (result[i] == 0)
            {
                continue;
            }

            result[j] = result[i];

            if (i > j)
            {
                result[i] = 0;
            }

            j++;
            length++;
        }

        result.RemoveRange(length, result.Count - length);

        return result;
    }
}
