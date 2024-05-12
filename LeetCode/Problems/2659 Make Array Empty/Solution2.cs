using JetBrains.Annotations;

namespace LeetCode.Problems._2659_Make_Array_Empty;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-103/submissions/detail/941631804/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long CountOperationsToEmptyArray(int[] nums)
    {
        var ans = 0L;
        var n = nums.Length;
        var indicesMap = Enumerable.Range(0, n).ToDictionary(i => nums[i]);
        var sorted = nums.OrderBy(num => num).ToArray();

        var takenIndices = new List<int>();

        var lastIndex = -1;

        for (var i = 0; i < n; i++)
        {
            var min = sorted[i];
            var index = indicesMap[min];

            var distance = index > lastIndex
                ? 0L + index - lastIndex - CountTakenIndices(lastIndex + 1, index)
                : 0L + index - lastIndex + n - CountTakenIndices(lastIndex + 1, n) - CountTakenIndices(0, index);

            ans += distance;

            var indexOfIndex = ~takenIndices.BinarySearch(index);
            takenIndices.Insert(indexOfIndex, index);
            lastIndex = index;
            continue;

            int CountTakenIndices(int from, int to)
            {
                var fromIndex = takenIndices.BinarySearch(from);

                if (fromIndex < 0)
                {
                    fromIndex = ~fromIndex;
                }

                var toIndex = takenIndices.BinarySearch(to);

                if (toIndex < 0)
                {
                    toIndex = ~toIndex - 1;
                }

                return toIndex - fromIndex + 1;
            }
        }

        return ans;
    }
}
