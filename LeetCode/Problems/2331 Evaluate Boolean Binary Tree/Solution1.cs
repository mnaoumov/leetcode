using JetBrains.Annotations;

namespace LeetCode.Problems._2331_Evaluate_Boolean_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1259173221/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool EvaluateTree(TreeNode root)
    {
        if (root.left == null && root.right == null)
        {
            return root.val switch
            {
                0 => false,
                1 => true,
                _ => throw new InvalidOperationException()
            };
        }

        Func<bool, bool, bool> fn = root.val switch
        {
            2 => (a, b) => a || b,
            3 => (a, b) => a && b,
            _ => throw new InvalidOperationException()
        };

        return fn(EvaluateTree(root.left!), EvaluateTree(root.right!));
    }
}
