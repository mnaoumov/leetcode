namespace LeetCode._0138_Copy_List_with_Random_Pointer;

public class Node
{
    // ReSharper disable once InconsistentNaming
    public readonly int val;
    // ReSharper disable once InconsistentNaming
    public Node? next;
    // ReSharper disable once InconsistentNaming
    public Node? random;

    public Node(int val)
    {
        this.val = val;
        next = null;
        random = null;
    }

    public static Node Create(int?[][] values)
    {
        var fakeRoot = new Node(0);

        var parent = fakeRoot;

        var list = new List<Node>();

        foreach (var arr in values)
        {
            var value = (int) arr[0]!;
            parent.next = new Node(value);
            list.Add(parent.next);
            parent = parent.next;
        }

        for (var index = 0; index < values.Length; index++)
        {
            var arr = values[index];
            var randomIndex = arr[1];

            if (randomIndex == null)
            {
                continue;
            }

            list[index].random = list[(int) randomIndex];
        }

        return fakeRoot.next!;
    }
}
