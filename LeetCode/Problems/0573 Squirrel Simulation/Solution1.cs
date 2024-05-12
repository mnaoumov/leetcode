using JetBrains.Annotations;

namespace LeetCode.Problems._0573_Squirrel_Simulation;

/// <summary>
/// https://leetcode.com/submissions/detail/1094089319/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[][] nuts)
    {
        var treePosition = Position.FromArray(tree);
        var squirrelPosition = Position.FromArray(squirrel);

        var totalNutTreeDistance = 0;
        var minSquirrelTreeDistanceDiff = int.MaxValue;

        foreach (var nut in nuts)
        {
            var nutPosition = Position.FromArray(nut);
            var nutTreeDistance = nutPosition.DistanceTo(treePosition);
            var nutSquirrelDistance = nutPosition.DistanceTo(squirrelPosition);
            totalNutTreeDistance += nutTreeDistance;
            minSquirrelTreeDistanceDiff = Math.Min(minSquirrelTreeDistanceDiff, nutSquirrelDistance - nutTreeDistance);
        }

        return 2 * totalNutTreeDistance + minSquirrelTreeDistanceDiff;
    }

    private record Position(int Row, int Column)
    {
        public static Position FromArray(IReadOnlyList<int> arr) => new(arr[0], arr[1]);
        public int DistanceTo(Position position) => Math.Abs(position.Row - Row) + Math.Abs(position.Column - Column);
    }
}
