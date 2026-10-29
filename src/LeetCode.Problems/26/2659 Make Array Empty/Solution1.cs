namespace LeetCode.Problems._2659_Make_Array_Empty;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-103/submissions/detail/941624861/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long CountOperationsToEmptyArray(int[] nums)
    {
        var ans = 0L;
        var n = nums.Length;
        var indicesMap = Enumerable.Range(0, n).ToDictionary(i => nums[i]);
        var sorted = nums.OrderBy(num => num).ToArray();

        var takenIndices = new SortedSet<int>();

        var lastIndex = -1;

        for (var i = 0; i < n; i++)
        {
            var min = sorted[i];
            var index = indicesMap[min];

            var distance = index > lastIndex
                ? 0L + index - lastIndex - takenIndices.GetViewBetween(lastIndex + 1, index).Count
                : 0L + index - lastIndex + n - takenIndices.GetViewBetween(lastIndex + 1, n).Count -
                  takenIndices.GetViewBetween(0, index).Count;

            ans += distance;
            takenIndices.Add(index);
            lastIndex = index;
        }

        return ans;
    }
}
