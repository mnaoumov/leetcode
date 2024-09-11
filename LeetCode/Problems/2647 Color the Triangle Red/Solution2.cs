namespace LeetCode.Problems._2647_Color_the_Triangle_Red;

/// <summary>
/// https://leetcode.com/submissions/detail/957314710/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[][] ColorRed(int n)
    {
        var list = new List<int[]> { new[] { 1, 1 } };

        for (var i = n; i >= 2; i--)
        {
            switch ((n - i) % 4)
            {
                case 0:
                    for (var j = 1; j <= 2 * i - 1; j += 2)
                    {
                        list.Add(new[] { i, j });
                    }
                    break;
                case 1:
                    list.Add(new[] { i, 2 });
                    break;
                case 2:
                    for (var j = 3; j <= 2 * i - 1; j += 2)
                    {
                        list.Add(new[] { i, j });
                    }
                    break;
                case 3:
                    list.Add(new[] { i, 1 });
                    break;
            }
        }

        return list.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
    }
}
