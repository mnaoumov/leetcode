using JetBrains.Annotations;

namespace LeetCode._0872_Leaf_Similar_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/856365153/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        return GetLeafValues(root1).SequenceEqual(GetLeafValues(root2));
    }

    private static IEnumerable<int> GetLeafValues(TreeNode? root)
    {
        if (root == null)
        {
            yield break;
        }

        if (root.left == null && root.right == null)
        {
            yield return root.val;
        }

        foreach (var value in GetLeafValues(root.left).Concat(GetLeafValues(root.right)))
        {
            yield return value;
        }
    }
}
