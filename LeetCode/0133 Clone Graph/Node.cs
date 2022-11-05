namespace LeetCode._0133_Clone_Graph;

public class Node
{
    // ReSharper disable once InconsistentNaming
    public readonly int val;
    // ReSharper disable once InconsistentNaming
    public readonly IList<Node> neighbors;

    public Node(int val)
    {
        this.val = val;
        neighbors = new List<Node>();
    }

    public static Node? Create(int[][] adjustmentLists)
    {
        var n = adjustmentLists.Length;

        if (n == 0)
        {
            return null;
        }

        var nodes = Enumerable.Range(1, n).Select(i => new Node(i)).ToArray();
        
        for (var i = 1; i <= adjustmentLists.Length; i++)
        {
            var adjustmentList = adjustmentLists[i - 1];

            foreach (var neighborValue in adjustmentList)
            {
                nodes[i - 1].neighbors.Add(nodes[neighborValue - 1]);
            }
        }

        return nodes[0];
    }
}