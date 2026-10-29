namespace LeetCode.Problems._1380_Lucky_Numbers_in_a_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/1325720915/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> LuckyNumbers (int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var rowMins = Enumerable.Range(0, m).Select(i => Enumerable.Range(0, n).Select(j => matrix[i][j]).Min())
            .ToArray();
        var columnMaxes = Enumerable.Range(0, n).Select(j => Enumerable.Range(0, m).Select(i => matrix[i][j]).Max())
            .ToArray();

        var ans = new List<int>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var val = matrix[i][j];

                if (val == rowMins[i] && val == columnMaxes[j])
                {
                    ans.Add(val);
                }
            }
        }

        return ans;
    }
}
