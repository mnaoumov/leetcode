namespace LeetCode.Problems._3394_Check_if_Grid_can_be_Cut_into_Sections;

/// <summary>
/// https://leetcode.com/problems/check-if-grid-can-be-cut-into-sections/submissions/1586075216/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        var rectangleObjs = rectangles.Select(r => new Rectangle(r[0], r[1], r[2], r[3])).ToArray();

        var xRanges = rectangleObjs.Select(r => new Range(r.StartX, r.EndX)).ToArray();
        var yRanges = rectangleObjs.Select(r => new Range(r.StartY, r.EndY)).ToArray();

        return CheckValidCuts(xRanges) || CheckValidCuts(yRanges);
    }

    private static bool CheckValidCuts(Range[] ranges)
    {
        const int requiredCutsCount = 3;

        ranges = ranges.OrderBy(r => r.Start).ThenByDescending(r => r.End).ToArray();

        var closestEnd = 0;
        var cutsCount = 0;

        foreach (var range in ranges)
        {
            if (range.Start >= closestEnd)
            {
                cutsCount++;

                if (cutsCount == requiredCutsCount)
                {
                    return true;
                }
            }

            closestEnd = Math.Max(closestEnd, range.End);
        }

        return false;
    }

    private record Rectangle(int StartX, int StartY, int EndX, int EndY);
    private record Range(int Start, int End);
}
