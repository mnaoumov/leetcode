using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0988_Smallest_String_Starting_From_Leaf;

/// <summary>
/// https://leetcode.com/submissions/detail/1234435910/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string SmallestFromLeaf(TreeNode root) => SmallestFromLeaf2(root);

    private static string SmallestFromLeaf2(TreeNode? node)
    {
        if (node == null)
        {
            return "";
        }

        var leftStr = SmallestFromLeaf2(node.left);
        var rightStr = SmallestFromLeaf2(node.right);

        string minStr;

        if (leftStr == "")
        {
            minStr = rightStr;
        }
        else if (rightStr == "")
        {
            minStr = leftStr;
        }
        else
        {
            minStr = string.CompareOrdinal(leftStr, rightStr) <= 0 ? leftStr : rightStr;
        }

        return minStr + (char) (node.val + 'a');
    }
}
