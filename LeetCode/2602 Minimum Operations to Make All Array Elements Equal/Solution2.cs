using JetBrains.Annotations;

namespace LeetCode._2602_Minimum_Operations_to_Make_All_Array_Elements_Equal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-338/submissions/detail/922172275/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<long> MinOperations(int[] nums, int[] queries)
    {
        Array.Sort(nums);
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 1; i < n + 1; i++)
        {
            prefixSums[i] = prefixSums[i - 1] + nums[i - 1];
        }

        return queries.Select(Answer).ToArray();

        long Answer(int query)
        {
            var index = Array.BinarySearch(nums, query);

            if (index < 0)
            {
                index = ~index;
            }

            return 1L * index * query - prefixSums[index] + prefixSums[n] - prefixSums[index] -
                   1L * (n - index) * query;
        }
    }
}
