namespace LeetCode.Problems._3132_Find_the_Integer_Added_to_Array_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1243762225/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumAddedInteger(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var counts1 = GetCounts(nums1);
        var counts2 = GetCounts(nums2);

        for (var i = 2; i >= 0; i--)
        {
            var x = nums2[0] - nums1[i];

            var countsDiff = 0;

            foreach (var num2 in counts2.Keys)
            {
                var num1 = num2 - x;

                var count1 = counts1.GetValueOrDefault(num1, 0);
                var count2 = counts2[num2];
                countsDiff += count1 - count2;

                if (countsDiff > 2)
                {
                    break;
                }
            }

            if (countsDiff <= 2)
            {
                return x;
            }
        }

        throw new InvalidOperationException();
    }

    private static Dictionary<int, int> GetCounts(IEnumerable<int> nums) =>
        nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
}
