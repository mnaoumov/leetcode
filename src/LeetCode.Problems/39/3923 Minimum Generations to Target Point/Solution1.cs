namespace LeetCode.Problems._1018203_Minimum_Generations_to_Target_Point;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-182/problems/minimum-generations-to-target-point/submissions/1999003896/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinGenerations(int[][] points, int[] target)
    {
        var pointsSet = points.Select(arr => new Point(arr[0], arr[1], arr[2])).ToHashSet();
        var pointsList = pointsSet.ToList();
        var targetObj = new Point(target[0], target[1], target[2]);

        var ans = 0;

        int previousCount;

        do
        {
            if (pointsSet.Contains(targetObj))
            {
                return ans;
            }

            previousCount = pointsSet.Count;

            for (var i = 0; i < previousCount; i++)
            {
                for (var j = i + 1; j < previousCount; j++)
                {
                    var newPoint = new Point((pointsList[i].X + pointsList[j].X) / 2,
                        (pointsList[i].Y + pointsList[j].Y) / 2, (pointsList[i].Z + pointsList[j].Z) / 2);

                    if (pointsSet.Add(newPoint))
                    {
                        pointsList.Add(newPoint);
                    }
                }
            }

            ans++;
        } while (previousCount != pointsSet.Count);

        return -1;
    }

    private sealed record Point(int X, int Y, int Z);
}
