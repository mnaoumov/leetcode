using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1367_Linked_List_in_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public bool IsSubPath(ListNode head, TreeNode root);
}
