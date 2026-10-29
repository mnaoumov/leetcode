namespace LeetCode.Problems._2975_Maximum_Square_Area_by_Removing_Fences_From_a_Field;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-377/submissions/detail/1127060309/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        const long modulo = 1_000_000_007;
        var horizontalBlockSizes = GetBlockSizes(m, hFences);
        var verticalBlockSizes = GetBlockSizes(n, vFences);

        var (sizes1, sizes2) = (horizontalBlockSizes, verticalBlockSizes);

        if (sizes1.Count > sizes2.Count)
        {
            (sizes1, sizes2) = (sizes2, sizes1);
        }

        foreach (var size in sizes1.OrderByDescending(size => size))
        {
            if (sizes2.Contains(size))
            {
                return (int) (1L * size * size % modulo);
            }
        }

        return -1;
    }

    private static HashSet<int> GetBlockSizes(int length, IEnumerable<int> fences)
    {
        var list = new List<int> { 1, length };
        list.AddRange(fences);
        list.Sort();
        var ans = new HashSet<int>();

        for (var i = 0; i < list.Count; i++)
        {
            for (var j = i + 1; j < list.Count; j++)
            {
                ans.Add(list[j] - list[i]);
            }
        }

        return ans;
    }
}
