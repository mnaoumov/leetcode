namespace LeetCode.Problems._0531_Lonely_Pixel_I;

/// <summary>
/// https://leetcode.com/problems/lonely-pixel-i/submissions/2186589354/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLonelyPixel(char[][] picture)
    {
        const char black = 'B';

        var m = picture.Length;
        var n = picture[0].Length;

        var blacksInRowCount = new int[m];
        var blacksInColumnCount = new int[n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var isBlack = picture[i][j] == black;

                if (!isBlack)
                {
                    continue;
                }

                blacksInRowCount[i]++;
                blacksInColumnCount[j]++;
            }
        }

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            if (blacksInRowCount[i] != 1)
            {
                continue;
            }

            for (var j = 0; j < n; j++)
            {
                if (blacksInColumnCount[j] != 1)
                {
                    continue;
                }

                var isBlack = picture[i][j] == black;

                if (isBlack)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
