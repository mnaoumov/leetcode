namespace LeetCode.Problems._0501_Find_Mode_in_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1088780151/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindMode(TreeNode root)
    {
        var ans = new List<int>();
        var maxCount = 0;
        var count = 0;
        var lastValue = int.MinValue;

        foreach (var val in Inorder(root))
        {
            if (val != lastValue)
            {
                lastValue = val;
                count = 0;
            }

            count++;
            if (count > maxCount)
            {
                ans.Clear();
                maxCount = count;
            }


            if (count == maxCount)
            {
                ans.Add(val);
            }
        }

        return ans.ToArray();
    }

    private static IEnumerable<int> Inorder(TreeNode? node) => node == null
        ? Enumerable.Empty<int>()
        : Inorder(node.left).Append(node.val).Concat(Inorder(node.right));
}
