namespace LeetCode._1485_Clone_Binary_Tree_With_Random_Pointer;

public class NodeCopy
{
    public int val;
    public NodeCopy? left;
    public NodeCopy? right;
    public NodeCopy? random;
    public NodeCopy(int val = 0, NodeCopy? left = null, NodeCopy? right = null, NodeCopy? random = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
        this.random = random;
    }
}