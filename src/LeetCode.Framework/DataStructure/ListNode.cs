using System.Globalization;

#pragma warning disable CA1051
namespace LeetCode.DataStructure;

[PublicAPI]
public class ListNode
{
    // ReSharper disable once InconsistentNaming
    public int val;
    // ReSharper disable once InconsistentNaming
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    /// <summary>
    /// Compares lists by their values. <see cref="ListNode"/> itself keeps reference equality, as LeetCode's does, so
    /// a solution may key a collection by node; a test that compares lists by value passes this comparer.
    /// </summary>
    public static IEqualityComparer<ListNode?> StructuralComparer { get; } = new ListNodeStructuralComparer();

    public override string ToString()
    {
        var values = new List<string>();
        var indices = new Dictionary<ListNode, int>(ReferenceEqualityComparer.Instance);
        var listNode = this;
        while (listNode != null)
        {
            if (indices.TryGetValue(listNode, out var cycleStart))
            {
                values.Add($"...cycle to index {cycleStart}");
                break;
            }

            indices.Add(listNode, values.Count);
            values.Add(listNode.val.ToString(CultureInfo.InvariantCulture));
            listNode = listNode.next;
        }

        return $"[{string.Join(",", values)}]";
    }

    public static ListNode Create(params int[] values)
    {
        if (values == null || values.Length == 0)
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

    public static ListNode? CreateOrNull(params int[] values) => values.Length > 0 ? Create(values) : null;

    public ListNode? FindNode(int value)
    {
        var visited = new HashSet<ListNode>(ReferenceEqualityComparer.Instance);
        for (var listNode = this; listNode != null && visited.Add(listNode); listNode = listNode.next)
        {
            if (listNode.val == value)
            {
                return listNode;
            }
        }

        return null;
    }

    [UsedImplicitly]
    public static ListNode? FromObject(object obj)
    {
        var values = ((object[]) obj)
            .Select(Convert.ToInt32)
            .ToArray();
        return CreateOrNull(values);
    }

    private sealed class ListNodeStructuralComparer : IEqualityComparer<ListNode?>
    {
        // Equal lists share every prefix, so hashing a bounded prefix keeps the Equals contract, cycles included.
        private const int HashedPrefixLength = 64;

        /// <summary>
        /// Walks both lists iteratively, so a long list does not overflow the stack. A cyclic list terminates: reaching
        /// a pair of nodes already compared means both value sequences repeat from there.
        /// </summary>
        public bool Equals(ListNode? x, ListNode? y)
        {
            var comparedPairs = new HashSet<(ListNode, ListNode)>(ReferencePairComparer<ListNode>.Instance);

            while (x != null && y != null)
            {
                if (ReferenceEquals(x, y) || !comparedPairs.Add((x, y)))
                {
                    return true;
                }

                if (x.val != y.val)
                {
                    return false;
                }

                x = x.next;
                y = y.next;
            }

            return x == null && y == null;
        }

        public int GetHashCode(ListNode? obj)
        {
            var hashCode = new HashCode();
            for (var i = 0; i < HashedPrefixLength && obj != null; i++)
            {
                hashCode.Add(obj.val);
                obj = obj.next;
            }

            return hashCode.ToHashCode();
        }
    }
}
