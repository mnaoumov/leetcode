using JetBrains.Annotations;

namespace LeetCode.Problems._3132_Find_the_Integer_Added_to_Array_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-395/submissions/detail/1243777166/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
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

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var num1 in counts1.Keys)
            {
                var num2 = num1 + x;

                var count1 = counts1[num1];
                var count2 = counts2.GetValueOrDefault(num2, 0);
                var diff = count1 - count2;

                if (diff < 0)
                {
                    countsDiff = 3;
                    break;
                }
                
                countsDiff += diff;

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
