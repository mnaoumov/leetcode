using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0988_Smallest_String_Starting_From_Leaf;

/// <summary>
/// https://leetcode.com/submissions/detail/1234438079/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string SmallestFromLeaf(TreeNode root) => SmallestFromLeaf2(root);

    private static string SmallestFromLeaf2(TreeNode? node)
    {
        if (node == null)
        {
            return "";
        }

        var letter = (char) (node.val + 'a');
        var leftStr = SmallestFromLeaf2(node.left) + letter;
        var rightStr = SmallestFromLeaf2(node.right) + letter;

        if (node.left == null)
        {
            return rightStr;
        }

        if (node.right == null)
        {
            return leftStr;
        }

        return string.CompareOrdinal(leftStr, rightStr) <= 0 ? leftStr : rightStr;
    }
}
