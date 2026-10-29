namespace LeetCode.Problems._3963_Create_Grid_With_Exactly_One_Path;

/// <summary>
/// https://leetcode.com/problems/create-grid-with-exactly-one-path/submissions/2183488660/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] CreateGrid(int m, int n)
    {
        var ans = new string[m];
        const char freeCell = '.';
        const char obstacle = '#';

        for (var i = 0; i < m; i++)
        {
            ans[i] = i == 0 ? new string(freeCell, n): new string(obstacle, n-1) + freeCell;
        }

        return ans;
    }
}
