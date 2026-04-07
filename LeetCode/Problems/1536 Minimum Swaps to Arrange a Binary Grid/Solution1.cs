namespace LeetCode.Problems._1536_Minimum_Swaps_to_Arrange_a_Binary_Grid;

/// <summary>
/// https://leetcode.com/problems/minimum-swaps-to-arrange-a-binary-grid/submissions/1936205059/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSwaps(int[][] grid)
    {
        var n = grid.Length;
        var rightOnes = Enumerable.Repeat(-1, n).ToList();

        for (var i = 0; i < n; i++)
        {
            var row = grid[i];

            for (var j = n - 1; j >= 0; j--)
            {
                if (row[j] != 1)
                {
                    continue;
                }

                rightOnes[i] = j;
                break;
            }
        }

        var sortedRightOnes = rightOnes.OrderBy(x => x).ToArray();

        if (!Enumerable.Range(0, n).All(i => sortedRightOnes[i] <= i))
        {
            const int impossible = -1;
            return impossible;
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                var rightOnePosition = rightOnes[j];

                if (rightOnePosition > i)
                {
                    continue;
                }

                ans += j - i;
                rightOnes.RemoveAt(j);
                rightOnes.Insert(i, rightOnePosition);
                break;
            }
        }

        return ans;
    }
}
