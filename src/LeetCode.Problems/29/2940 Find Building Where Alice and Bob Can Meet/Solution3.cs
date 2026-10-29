namespace LeetCode.Problems._2940_Find_Building_Where_Alice_and_Bob_Can_Meet;

/// <summary>
/// https://leetcode.com/submissions/detail/1486760141/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
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
        var candidateIndicesReversed = new List<int>();

        foreach (var query in queryObjs)
        {
            for (var i = lastIndex - 1; i >= query.MaxIndex; i--)
            {
                while (candidateIndicesReversed.Count > 0 && heights[candidateIndicesReversed[^1]] <= heights[i])
                {
                    candidateIndicesReversed.RemoveAt(candidateIndicesReversed.Count - 1);
                }

                candidateIndicesReversed.Add(i);
            }

            lastIndex = query.MaxIndex;

            if (heights[query.MinIndex] < heights[query.MaxIndex] || query.MinIndex == query.MaxIndex)
            {
                ans[query.Index] = query.MaxIndex;
                continue;
            }

            if (heights[candidateIndicesReversed[0]] < heights[query.MinIndex] + 1)
            {
                ans[query.Index] = -1;
                continue;
            }

            var low = 1;
            var high = candidateIndicesReversed.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);
                var index = candidateIndicesReversed[mid];
                var height = heights[index];
                if (height <= heights[query.MinIndex] + 1)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            ans[query.Index] = candidateIndicesReversed[high];
        }

        return ans;
    }

    private record Query(int Index, int MinIndex, int MaxIndex);
}
