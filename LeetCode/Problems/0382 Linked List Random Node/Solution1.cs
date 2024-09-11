using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0382_Linked_List_Random_Node;

/// <summary>
/// https://leetcode.com/submissions/detail/912406020/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISolutionImpl Create(ListNode head) => new Solution(head);

    private class Solution : ISolutionImpl
    {
        private readonly ListNode _head;
        private readonly int _length;
        private readonly Random _random;

        public Solution(ListNode head)
        {
            _head = head;

            _length = 0;

            for (var node = head; node != null; node = node.next)
            {
                _length++;
            }

            _random = new Random();
        }

        public int GetRandom()
        {
            var randomDistance = _random.Next(_length);

            var node = _head;

            for (var i = 0; i < randomDistance; i++)
            {
                node = node.next!;
            }

            return node.val;
        }
    }
}
