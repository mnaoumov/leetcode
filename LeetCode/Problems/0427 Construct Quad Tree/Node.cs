namespace LeetCode._0427_Construct_Quad_Tree;

public class Node
{
    // ReSharper disable InconsistentNaming
    public readonly bool val;
    public readonly bool isLeaf;
    public Node? topLeft;
    public Node? topRight;
    public Node? bottomLeft;
    public Node? bottomRight;
    // ReSharper restore InconsistentNaming


    public Node()
    {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool val, bool isLeaf)
    {
        this.val = val;
        this.isLeaf = isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
}
