namespace LeetCode.Problems._3355_Zero_Array_Transformation_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-424/submissions/detail/1454861384/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        var n = nums.Length;
        var points = new List<int> { 0 };
        var counts = new Dictionary<int, int>
        {
            [0] = 0
        };

        foreach (var query in queries)
        {
            var l = query[0];
            var r = query[1];
            var leftIndex = points.BinarySearch(l);
            if (leftIndex < 0)
            {
                leftIndex = ~leftIndex;
                points.Insert(leftIndex, l);
                counts[l] = counts[points[leftIndex - 1]];
            }

            var rightIndex = points.BinarySearch(r + 1);
            if (rightIndex < 0)
            {
                rightIndex = ~rightIndex;

                points.Insert(rightIndex, r + 1);
                counts[r + 1] = counts[points[rightIndex - 1]];
            }

            for (var i = leftIndex; i < rightIndex; i++)
            {
                var point = points[i];
                counts[point]++;
            }
        }

        for (var i = 0; i < n; i++)
        {
            var index = points.BinarySearch(i);
            if (index < 0)
            {
                index = ~index - 1;
            }

            if (index < 0)
            {
                return false;
            }

            if (counts[points[index]] < nums[index])
            {
                return false;
            }
        }

        return true;
    }
}
