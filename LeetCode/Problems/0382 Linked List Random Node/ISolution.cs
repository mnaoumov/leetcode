using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0382_Linked_List_Random_Node;

[PublicAPI]
public interface ISolution
{
    public ISolutionImpl Create(ListNode head);
}
