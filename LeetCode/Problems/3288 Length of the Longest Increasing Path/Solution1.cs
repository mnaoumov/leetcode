namespace LeetCode.Problems._3288_Length_of_the_Longest_Increasing_Path;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int MaxPathLength(int[][] coordinates, int k)
    {
        var coordinateObjs = coordinates.Select(arr => new Coordinate(arr[0], arr[1])).ToArray();
        var requiredCoordinate = coordinateObjs[k];
        var smallerCoordinates = coordinateObjs.Where(c => c < requiredCoordinate).OrderByDescending(c => c.X + c.Y)
            .ToArray();
        var greaterCoordinates = coordinateObjs.Where(c => c > requiredCoordinate).OrderBy(c => c.X + c.Y)
            .ToArray();

        foreach (var coordinate in greaterCoordinates)
        {
            
        }

        return 0;
    }

    private record Coordinate(int X, int Y)
    {
        public static bool operator <(Coordinate a, Coordinate b) => a.X < b.X && a.Y < b.Y;
        public static bool operator >(Coordinate a, Coordinate b) => a.X > b.X && a.Y > b.Y;
    }
}
