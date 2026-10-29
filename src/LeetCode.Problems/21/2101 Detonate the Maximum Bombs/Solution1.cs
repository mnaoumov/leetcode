namespace LeetCode.Problems._2101_Detonate_the_Maximum_Bombs;

/// <summary>
/// https://leetcode.com/submissions/detail/906954084/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumDetonation(int[][] bombs)
    {
        var n = bombs.Length;

        var adjacentBombs = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (j == i)
                {
                    continue;
                }

                if (IsWithinRange(bombs[i], bombs[j]))
                {
                    adjacentBombs[i].Add(j);
                }
            }
        }

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            var seen = new HashSet<int>();
            var bombsCount = 0;
            Dfs(i);
            result = Math.Max(result, bombsCount);
            continue;

            void Dfs(int bombId)
            {
                if (!seen.Add(bombId))
                {
                    return;
                }

                bombsCount++;

                foreach (var adjacentBombId in adjacentBombs[bombId])
                {
                    Dfs(adjacentBombId);
                }
            }
        }

        return result;
    }

    private static bool IsWithinRange(IReadOnlyList<int> bomb1, IReadOnlyList<int> bomb2)
    {
        var x1 = bomb1[0];
        var y1 = bomb1[1];
        var r1 = bomb1[2];
        var x2 = bomb2[0];
        var y2 = bomb2[1];
        return Square(x2 - x1) + Square(y2 - y1) <= Square(r1);
    }

    private static long Square(int x) => 1L * x * x;
}
