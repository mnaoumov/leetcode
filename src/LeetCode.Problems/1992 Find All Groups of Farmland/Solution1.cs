namespace LeetCode.Problems._1992_Find_All_Groups_of_Farmland;

/// <summary>
/// https://leetcode.com/submissions/detail/1237707229/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] FindFarmland(int[][] land)
    {
        var m = land.Length;
        var n = land[0].Length;
        const int farmland = 1;

        var list = new List<int[]>();

        for (var top = 0; top < m; top++)
        {
            for (var left = 0; left < n; left++)
            {
                if (land[top][left] != farmland)
                {
                    continue;
                }

                if (top > 0 && land[top - 1][left] == farmland)
                {
                    continue;
                }

                if (left > 0 && land[top][left - 1] == farmland)
                {
                    continue;
                }


                var bottom = top;
                var right = left;

                while (bottom + 1 < m && land[bottom + 1][left] == farmland)
                {
                    bottom++;
                }

                while (right + 1 < n && land[top][right + 1] == farmland)
                {
                    right++;
                }

                list.Add(new[] { top, left, bottom, right });
            }
        }

        return list.ToArray();
    }
}
