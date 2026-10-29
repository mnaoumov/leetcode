namespace LeetCode.Problems._0108_Convert_Sorted_Array_to_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/830127551/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Build(0, nums.Length - 1)!;

        TreeNode? Build(int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var mid = (left + right) / 2;

            return new TreeNode
            {
                val = nums[mid],
                left = Build(left, mid - 1),
                right = Build(mid + 1, right)
            };
        }
    }
}
