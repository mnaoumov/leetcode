namespace LeetCode.Problems._2485_Find_the_Pivot_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/850790845/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PivotInteger(int n)
    {
        var sum = n * (n + 1) / 2;
        var k = (int) Math.Sqrt(sum);

        return k * k == sum ? k : -1;
    }
}
