namespace LeetCode.Problems._2643_Row_With_Maximum_Ones;

/// <seealso href="https://leetcode.com/contest/weekly-contest-341/submissions/detail/934447784/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] RowAndMaximumOnes(int[][] mat)
    {
        var m = mat.Length;

        var group = Enumerable.Range(0, m).GroupBy(i => mat[i].Count(num => num == 1)).MaxBy(g => g.Key)!;
        return new[] { group.Min(), group.Key };
    }
}
