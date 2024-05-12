using JetBrains.Annotations;

namespace LeetCode._1361_Validate_Binary_Tree_Nodes;

[PublicAPI]
public interface ISolution
{
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild);
}
