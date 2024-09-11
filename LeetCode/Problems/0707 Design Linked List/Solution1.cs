namespace LeetCode.Problems._0707_Design_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/899430544/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyLinkedList Create() => new MyLinkedList();

    private class MyLinkedList : IMyLinkedList
    {
        private readonly Node _fakeHead = new();
        private int _length;

        public int Get(int index)
        {
            if (index < 0 || index >= _length)
            {
                return -1;
            }

            var node = _fakeHead.Next!;

            for (var i = 0; i < index; i++)
            {
                node = node.Next!;
            }

            return node.Value;
        }

        public void AddAtHead(int val) => AddAtIndex(0, val);

        public void AddAtTail(int val) => AddAtIndex(_length, val);

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > _length)
            {
                return;
            }

            var node = _fakeHead;

            for (var i = 0; i < index; i++)
            {
                node = node.Next!;
            }

            node.Next = node with { Value = val };

            _length++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= _length)
            {
                return;
            }

            var node = _fakeHead;

            for (var i = 0; i < index; i++)
            {
                node = node.Next!;
            }

            node.Next = node.Next!.Next;
            _length--;
        }

        private record Node
        {
            public int Value { get; init; }
            public Node? Next { get; set; }
        }
    }
}
