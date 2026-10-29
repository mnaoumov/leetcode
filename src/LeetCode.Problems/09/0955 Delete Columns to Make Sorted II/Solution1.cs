namespace LeetCode.Problems._0955_Delete_Columns_to_Make_Sorted_II;

/// <summary>
/// https://leetcode.com/problems/delete-columns-to-make-sorted-ii/submissions/1861068789/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDeletionSize(string[] strs)
    {
        var n = strs.Length;
        var sortedSubstrings = Enumerable.Repeat("", n).ToArray();

        var m = strs[0].Length;
        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            var doesStaySorted = true;
            for (var j = 0; j < n; j++)
            {
                for (var k = j + 1; k < n; k++)
                {
                    if (string.Compare(sortedSubstrings[j], sortedSubstrings[k], StringComparison.Ordinal) < 0)
                    {
                        continue;
                    }

                    if (strs[j][i] <= strs[k][i])
                    {
                        continue;
                    }

                    doesStaySorted = false;
                    break;
                }

                if (!doesStaySorted)
                {
                    break;
                }
            }

            if (doesStaySorted)
            {
                for (var j = 0; j < n; j++)
                {
                    sortedSubstrings[j] += strs[j][i];
                }
            }
            else
            {
                ans++;
            }
        }

        return ans;
    }
}
