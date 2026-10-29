namespace LeetCode.Problems._0757_Set_Intersection_Size_At_Least_Two;

/// <summary>
/// https://leetcode.com/problems/set-intersection-size-at-least-two/submissions/1834761454/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        var intervalObjs = intervals.Select(arr => new Interval(arr[0], arr[1])).OrderBy(x => x.End)
            .ThenByDescending(x => x.Start).ToArray();
        var ans = 0;
        var n = intervalObjs.Length;

        for (var i = 0; i < n; i++)
        {
            var interval = intervalObjs[i];
            var coveredNumbersCount = interval.CoveredNumbersCount;

            for (var num = interval.End; num >= interval.End + coveredNumbersCount - 1; num--)
            {
                ans++;

                for (var j = i; j < n; j++)
                {
                    var interval2 = intervalObjs[j];

                    if (interval2.Start <= num && num <= interval2.End)
                    {
                        interval2.CoveredNumbersCount++;
                    }
                }
            }
        }

        return ans;
    }

    private record Interval(int Start, int End)
    {
        public int CoveredNumbersCount { get; set; }
    }
}
