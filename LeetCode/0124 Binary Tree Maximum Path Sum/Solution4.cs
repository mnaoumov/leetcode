using JetBrains.Annotations;

namespace LeetCode._0124_Binary_Tree_Maximum_Path_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/836383933/
/// https://leetcode.com/submissions/detail/858339754/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaxPathSum(TreeNode root)
    {
        var directPathDict = new Dictionary<TreeNode, int>();

        return GetForAnyPath(root);

        int GetForAnyPath(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            return new int?[]
            {
                node.left == null ? null : GetForAnyPath(node.left),
                node.right == null ? null : GetForAnyPath(node.right),
                GetForDirectPath(node.left) + node.val + GetForDirectPath(node.right)
            }.OfType<int>().Max();
        }

        int GetForDirectPath(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            if (directPathDict.TryGetValue(node, out var result))
            {
                return result;
            }

            directPathDict[node] = result = Math.Max(0,
                node.val + Math.Max(GetForDirectPath(node.left), GetForDirectPath(node.right)));

            return result;

        }
    }
}
