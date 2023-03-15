namespace LeetCode._1485_Clone_Binary_Tree_With_Random_Pointer;

public class Node
{
    public int val;
    public Node? left;
    public Node? right;
    public Node? random;
    public Node(int val = 0, Node? left = null, Node? right = null, Node? random = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
        this.random = random;
    }
}