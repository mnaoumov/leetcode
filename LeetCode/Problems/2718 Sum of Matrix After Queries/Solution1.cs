using JetBrains.Annotations;

namespace LeetCode.Problems._2718_Sum_of_Matrix_After_Queries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-348/submissions/detail/963344722/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MatrixSumQueries(int n, int[][] queries)
    {
        var rowsUsed = new HashSet<int>();
        var columnsUsed = new HashSet<int>();
        var ans = 0L;
        const int rowType = 0;

        for (var i = queries.Length - 1; i >= 0; i--)
        {
            var query = queries[i];
            var type = query[0];
            var index = query[1];
            var val = query[2];

            if (type == rowType)
            {
                if (!rowsUsed.Add(index))
                {
                    continue;
                }

                ans += 1L * val * (n - columnsUsed.Count);

                if (rowsUsed.Count == n)
                {
                    break;
                }
            }
            else
            {
                if (!columnsUsed.Add(index))
                {
                    continue;
                }

                ans += 1L * val * (n - rowsUsed.Count);

                if (columnsUsed.Count == n)
                {
                    break;
                }
            }
        }

        return ans;
    }
}
