namespace LeetCode.Problems._1198_Find_Smallest_Common_Element_in_All_Rows;

/// <summary>
/// https://leetcode.com/problems/find-smallest-common-element-in-all-rows/submissions/1727443179/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestCommonElement(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        for (var j = 0; j < n; j++)
        {
            var candidate = mat[0][j];
            var found = true;
            for (var i = 1; i < m; i++)
            {
                var index = Array.BinarySearch(mat[i], candidate);

                if (index >= 0)
                {
                    continue;
                }

                found = false;
                break;
            }
            if (found)
            {
                return candidate;
            }
        }

        return -1;
    }
}
