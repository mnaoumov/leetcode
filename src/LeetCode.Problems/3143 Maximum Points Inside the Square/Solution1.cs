namespace LeetCode.Problems._3143_Maximum_Points_Inside_the_Square;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-130/submissions/detail/1255239362/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxPointsInsideSquare(int[][] points, string s)
    {
        var n = points.Length;

        var distanceToTags = new Dictionary<int, List<char>>();

        for (var i = 0; i < n; i++)
        {
            var point = points[i];
            var distance = Math.Max(Math.Abs(point[0]), Math.Abs(point[1]));
            var tag = s[i];

            distanceToTags.TryAdd(distance, new List<char>());
            distanceToTags[distance].Add(tag);
        }

        var ans = 0;
        var usedTags = new HashSet<char>();

        foreach (var distance in distanceToTags.Keys.OrderBy(x => x))
        {
            var tags = distanceToTags[distance];

            var isValidDistance = tags.All(usedTags.Add);

            if (!isValidDistance)
            {
                break;
            }

            ans = distance;
        }

        return ans;
    }
}
