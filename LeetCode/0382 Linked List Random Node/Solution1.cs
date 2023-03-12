using JetBrains.Annotations;

namespace LeetCode._0382_Linked_List_Random_Node;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISolutionImpl Create(ListNode head)
    {
        return new SolutionImpl1(head);
    }
}
