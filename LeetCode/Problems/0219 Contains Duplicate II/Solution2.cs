namespace LeetCode.Problems._0219_Contains_Duplicate_II;

/// <summary>
/// https://leetcode.com/submissions/detail/826954508/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        if (k == 0)
        {
            return false;
        }

        var set = new HashSet<int>(capacity: k + 1);

        for (var i = 0; i < nums.Length; i++)
        {
            if (i >= k + 1)
            {
                set.Remove(nums[i - k - 1]);
            }

            if (!set.Add(nums[i]))
            {
                return true;
            }
        }

        return false;
    }
}
