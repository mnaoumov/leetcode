namespace LeetCode.Problems._3510_Minimum_Pair_Removal_to_Sort_Array_II;

/// <summary>
/// https://leetcode.com/problems/minimum-pair-removal-to-sort-array-ii/submissions/1895730732/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumPairRemoval(int[] nums)
    {
        var list = new LinkedList<ValueWithIndex>(nums.Select((num, index) => new ValueWithIndex(index, num)));

        var decreaseCount = 0;

        var pq = new PriorityQueue<Item, (long sum, int index)>();

        var node = list.First;


        while (node?.Next != null)
        {
            var item = new Item(node, node.Value.Value, node.Next.Value.Value);
            pq.Enqueue(item, item.Key);

            if (item.Value > item.NextValue)
            {
                decreaseCount++;
            }

            node = node.Next;
        }

        var ans = 0;

        var removedIndices = new HashSet<int>();

        while (decreaseCount > 0)
        {
            var item = pq.Dequeue();

            if (item.Value != item.Node.Value.Value || item.NextValue != item.Node.Next?.Value.Value || removedIndices.Contains(item.Node.Next.Value.Index))
            {
                continue;
            }

            ans++;
            removedIndices.Add(item.Node.Next.Value.Index);

            var newValue = 0L + item.Value + item.NextValue;

            item.Node.Value = item.Node.Value with { Value = newValue };
            list.Remove(item.Node.Next);

            if (item.Node.Previous != null)
            {
                var previousItem = new Item(item.Node.Previous, item.Node.Previous.Value.Value, item.Node.Value.Value);
                pq.Enqueue(previousItem, previousItem.Key);
            }

            if (item.Node.Next != null)
            {
                var nextItem = new Item(item.Node, item.Node.Value.Value, item.Node.Next.Value.Value);
                pq.Enqueue(nextItem, nextItem.Key);
            }

            var oldDecreaseCount =
                (item.Node.Previous != null && item.Node.Previous.Value.Value > item.Value ? 1 : 0)
                + (item.Value > item.NextValue ? 1 : 0)
                + (item.Node.Next != null && item.NextValue > item.Node.Next.Value.Value ? 1 : 0);
            var newDecreaseCount =
                (item.Node.Previous != null && item.Node.Previous.Value.Value > newValue ? 1 : 0)
                + (item.Node.Next != null && newValue > item.Node.Next.Value.Value ? 1 : 0);
            decreaseCount -= oldDecreaseCount;
            decreaseCount += newDecreaseCount;
        }

        return ans;
    }

    private record ValueWithIndex(int Index, long Value);

    private record Item(LinkedListNode<ValueWithIndex> Node, long Value, long NextValue)
    {
        public (long sum, int index) Key => (0L + Value + NextValue, Node.Value.Index);
    }
}
