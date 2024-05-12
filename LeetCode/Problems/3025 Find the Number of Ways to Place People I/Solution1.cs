using JetBrains.Annotations;

namespace LeetCode._3025_Find_the_Number_of_Ways_to_Place_People_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-123/submissions/detail/1164857811/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfPairs(int[][] points)
    {
        var pointObjs = points.Select(Point.FromArray).OrderBy(p => p.X).ThenByDescending(p => p.Y).ToArray();
        var n = pointObjs.Length;

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var chisato = pointObjs[i];

            for (var j = i + 1; j < n; j++)
            {
                var takina = pointObjs[j];

                if (chisato.Y < takina.Y)
                {
                    continue;
                }

                var canPutOtherInsideFence = false;

                for (var k = i + 1; k < j; k++)
                {
                    var other = pointObjs[k];

                    if (chisato.Y < other.Y || other.Y < takina.Y)
                    {
                        continue;
                    }

                    canPutOtherInsideFence = true;
                    break;
                }

                if (!canPutOtherInsideFence)
                {
                    ans++;
                }
            }
        }

        return ans;
    }

    private record Point(int X, int Y)
    {
        public static Point FromArray(IReadOnlyList<int> arr) => new(arr[0], arr[1]);
    }
}
