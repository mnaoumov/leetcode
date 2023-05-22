using JetBrains.Annotations;

namespace LeetCode._0750_Number_Of_Corner_Rectangles;

/// <summary>
/// https://leetcode.com/submissions/detail/954777121/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCornerRectangles(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var oneColumnIndices = Enumerable.Range(0, m).Select(_ => new HashSet<int>()).ToArray();

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            var list = new List<int>();

            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != 1)
                {
                    continue;
                }

                oneColumnIndices[i].Add(j);
                list.Add(j);
            }

            for (var k = 0; k < i; k++)
            {
                for (var index1 = 0; index1 < list.Count; index1++)
                {
                    var column1 = list[index1];

                    if (!oneColumnIndices[k].Contains(column1))
                    {
                        continue;
                    }

                    for (var index2 = index1 + 1; index2 < list.Count; index2++)
                    {
                        var column2 = list[index2];

                        if (!oneColumnIndices[k].Contains(column2))
                        {
                            continue;
                        }

                        ans++;
                    }
                }
            }
        }

        return ans;
    }
}
