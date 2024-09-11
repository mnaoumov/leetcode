namespace LeetCode.Problems._0944_Delete_Columns_to_Make_Sorted;

/// <summary>
/// https://leetcode.com/submissions/detail/870069738/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDeletionSize(string[] strs)
    {
        var result = 0;

        var n = strs.Length;
        var m = strs[0].Length;

        for (var j = 0; j < m; j++)
        {
            for (var i = 0; i < n - 1; i++)
            {
                if (strs[i][j] <= strs[i + 1][j])
                {
                    continue;
                }

                result++;
                break;
            }
        }

        return result;
    }
}
