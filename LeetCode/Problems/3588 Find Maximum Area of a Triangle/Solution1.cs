namespace LeetCode.Problems._3588_Find_Maximum_Area_of_a_Triangle;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-159/problems/find-maximum-area-of-a-triangle/submissions/1671675260/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxArea(int[][] coords)
    {
        var points = coords.Select(c => new Point(c[0], c[1])).ToArray();
        var pointGroupsByX = points
            .GroupBy(p => p.X)
            .Select(g => new PointGroup(KeyDimension: g.Key, OtherDimensions: g.Select(p => p.Y).OrderBy(y => y).ToArray()))
            .OrderBy(q => q.KeyDimension)
            .ToArray();

        var pointGroupsByY = points
            .GroupBy(p => p.Y)
            .Select(g => new PointGroup(KeyDimension: g.Key, OtherDimensions: g.Select(p => p.X).OrderBy(x => x).ToArray()))
            .OrderBy(q => q.KeyDimension)
            .ToArray();

        var ans = -1L;

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var groups in new[] { pointGroupsByX, pointGroupsByY })
        {
            if (groups.Length == 1)
            {
                continue;
            }

            foreach (var group in groups)
            {
                if (group.OtherDimensions.Length < 2)
                {
                    continue;
                }

                var width = group.OtherDimensions[^1] - group.OtherDimensions[0];
                var height = Math.Max(group.KeyDimension - groups[0].KeyDimension,
                    groups[^1].KeyDimension - group.KeyDimension);
                var area = 1L * width * height;
                ans = Math.Max(ans, area);
            }
        }

        return ans;
    }

    private record Point(int X, int Y);

    private record PointGroup(int KeyDimension, int[] OtherDimensions);
}