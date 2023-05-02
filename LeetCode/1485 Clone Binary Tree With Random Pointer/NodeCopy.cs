namespace LeetCode._1485_Clone_Binary_Tree_With_Random_Pointer;

public class NodeCopy
{
    // ReSharper disable once InconsistentNaming
    public int val;

    // ReSharper disable once InconsistentNaming
    public NodeCopy? left;

    // ReSharper disable once InconsistentNaming
    public NodeCopy? right;

    // ReSharper disable once InconsistentNaming
    public NodeCopy? random;

    public NodeCopy(int val = 0, NodeCopy? left = null, NodeCopy? right = null, NodeCopy? random = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
        this.random = random;
    }
}
