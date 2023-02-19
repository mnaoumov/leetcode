using JetBrains.Annotations;

namespace LeetCode._0707_Design_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/899430544/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyLinkedList Create()
    {
        return new MyLinkedList1();
    }
}
