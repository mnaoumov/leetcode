namespace LeetCode.Problems._2940_Find_Building_Where_Alice_and_Bob_Can_Meet;

/// <summary>
/// https://leetcode.com/submissions/detail/1486691693/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        var m = queries.Length;

        var queryObjs = queries.Select((arr, index) =>
                new Query(index, Math.Min(arr[0], arr[1]), Math.Max(arr[0], arr[1])))
            .OrderByDescending(q => q.MaxIndex)
            .ToArray();

        var ans = new int[m];

        var lastIndex = heights.Length;
        var candidateIndices = new List<int>();

        foreach (var query in queryObjs)
        {
            for (var i = lastIndex - 1; i >= query.MaxIndex; i--)
            {
                while (candidateIndices.Count > 0 && heights[candidateIndices[0]] <= heights[i])
                {
                    candidateIndices.RemoveAt(0);
                }

                candidateIndices.Insert(0, i);
            }

            lastIndex = query.MaxIndex;

            if (heights[query.MinIndex] < heights[query.MaxIndex] || query.MinIndex == query.MaxIndex)
            {
                ans[query.Index] = query.MaxIndex;
                continue;
            }

            var low = 0;
            var high = candidateIndices.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);
                var index = candidateIndices[mid];
                var height = heights[index];
                if (height >= heights[query.MinIndex])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            ans[query.Index] = low == candidateIndices.Count ? -1 : candidateIndices[low];
        }

        return ans;
    }

    private record Query(int Index, int MinIndex, int MaxIndex);
}
