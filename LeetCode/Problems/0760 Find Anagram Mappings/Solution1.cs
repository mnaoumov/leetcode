using JetBrains.Annotations;

namespace LeetCode.Problems._0760_Find_Anagram_Mappings;

/// <summary>
/// https://leetcode.com/submissions/detail/925744434/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] AnagramMappings(int[] nums1, int[] nums2)
    {
        var valueIndexMap = nums2.Select((num, index) => (num, index)).GroupBy(x => x.num, x => x.index)
            .ToDictionary(g => g.Key, g => g.ToArray());
        return nums1.Select(num1 => valueIndexMap[num1][0]).ToArray();
    }
}
