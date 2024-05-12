using JetBrains.Annotations;

namespace LeetCode.Problems._0235_Lowest_Common_Ancestor_of_a_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/906173583/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var pathToP = GetPath(root, p);
        var pathToQ = GetPath(root, q);
        return pathToP.Zip(pathToQ).TakeWhile(x => ReferenceEquals(x.First, x.Second)).Last().First;
    }

    private static IEnumerable<TreeNode> GetPath(TreeNode source, TreeNode target)
    {
        var result = new[] { source };
        return ReferenceEquals(source, target) ? result : result.Concat(source.val > target.val ? GetPath(source.left!, target) : GetPath(source.right!, target));
    }
}
