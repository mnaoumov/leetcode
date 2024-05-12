using JetBrains.Annotations;

namespace LeetCode.Problems._0442_Find_All_Duplicates_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1213909277/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindDuplicates(int[] nums)
    {
        var set = new HashSet<int>();
        return nums.Where(num => !set.Add(num)).ToList();
    }
}
