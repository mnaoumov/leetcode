using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2196_Create_Binary_Tree_From_Descriptions;

[PublicAPI]
public interface ISolution
{
    public TreeNode CreateBinaryTree(int[][] descriptions);
}
