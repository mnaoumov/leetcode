using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2236_Root_Equals_Sum_of_Children;

/// <summary>
/// https://leetcode.com/submissions/detail/864597927/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckTree(TreeNode root) => root.val == root.left!.val + root.right!.val;
}
