using JetBrains.Annotations;

namespace LeetCode._0382_Linked_List_Random_Node;

[PublicAPI]
public interface ISolution
{
    public ISolutionImpl Create(ListNode head);
}
