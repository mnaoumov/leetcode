namespace LeetCode.Problems._2236_Root_Equals_Sum_of_Children;

/// <seealso href="https://leetcode.com/submissions/detail/864597927/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckTree(TreeNode root) => root.val == root.left!.val + root.right!.val;
}
