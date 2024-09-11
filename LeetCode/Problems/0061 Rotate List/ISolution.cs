using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0061_Rotate_List;

[PublicAPI]
public interface ISolution
{
    public ListNode RotateRight(ListNode head, int k);
}
