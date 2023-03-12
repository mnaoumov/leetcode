namespace LeetCode._0382_Linked_List_Random_Node;

/// <summary>
/// https://leetcode.com/submissions/detail/912406020/
/// </summary>
public class SolutionImpl1 : ISolutionImpl
{
    private readonly ListNode _head;
    private readonly int _length;
    private readonly Random _random;

    public SolutionImpl1(ListNode head)
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
