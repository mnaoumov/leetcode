namespace LeetCode._218_The_Skyline_Problem;

/// <summary>
/// https://leetcode.com/submissions/detail/812157965/
/// </summary>
public class Solution : ISolution
{
    public IList<IList<int>> GetSkyline(int[][] buildings)
    {
        var buildingObjs = buildings.Select(b => new Building(b[0], b[1], b[2])).ToArray();

        var sortedXs = buildingObjs.SelectMany(b => new[] { b.Left, b.Right }).Distinct().OrderBy(x => x).ToArray();

        var result = new List<IList<int>>();

        int? lastMastHeight = null;

        foreach (var x in sortedXs)
        {
            var buildingsAtX = buildingObjs.Where(b => b.Left <= x && x < b.Right).Select(b => b.Height).ToArray();
            var maxHeight = buildingsAtX.Any() ? buildingsAtX.Max() : 0;
            if (maxHeight != lastMastHeight)
            {
                result.Add(new[] { x, maxHeight });
                lastMastHeight = maxHeight;
            }
        }

        return result;
    }

    private record Building(int Left, int Right, int Height);
}