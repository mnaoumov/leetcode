namespace LeetCode;

public class ListNode
{
    // ReSharper disable once InconsistentNaming
    public readonly int val;
    // ReSharper disable once InconsistentNaming
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ListNode listNode)
        {
            return false;
        }

        return Equals((val, next), (listNode.val, listNode.next));
    }

    public override string ToString()
    {
        var values = new List<int>();
        var listNode = this;
        while (listNode != null)
        {
            values.Add(listNode.val);
            listNode = listNode.next;
        }

        return $"[{string.Join(",", values)}]";
    }

    // ReSharper disable NonReadonlyMemberInGetHashCode
    public override int GetHashCode() => (val, next).GetHashCode();
    // ReSharper restore NonReadonlyMemberInGetHashCode

    public static ListNode Create(params int[] values)
    {
        if (values.Length == 0)
        {
            throw new ArgumentException("No values", nameof(values));
        }

        ListNode listNode = null!;
        for (var i = values.Length - 1; i >= 0; i--)
        {
            listNode = new ListNode(values[i], listNode);
        }

        return listNode;
    }

    public static ListNode? CreateOrNull(params int[] values)
    {
        return values.Any() ? Create(values) : null;
    }
}