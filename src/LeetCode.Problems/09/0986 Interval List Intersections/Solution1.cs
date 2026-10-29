namespace LeetCode.Problems._0986_Interval_List_Intersections;

/// <summary>
/// https://leetcode.com/submissions/detail/933427832/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        var index1 = 0;
        var index2 = 0;

        var result = new List<int[]>();


        while (index1 < firstList.Length && index2 < secondList.Length)
        {
            var interval1 = firstList[index1];
            var interval2 = secondList[index2];

            if (interval1[1] < interval2[0])
            {
                index1++;
            }
            else if (interval2[1] < interval1[0])
            {
                index2++;
            }
            else
            {
                var a = Math.Max(interval1[0], interval2[0]);
                var b = Math.Min(interval1[1], interval2[1]);
                result.Add(new[] { a, b });

                if (interval1[1] <= interval2[1])
                {
                    index1++;
                }
                else
                {
                    index2++;
                }
            }
        }

        return result.ToArray();
    }
}
