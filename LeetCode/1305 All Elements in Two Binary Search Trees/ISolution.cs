using JetBrains.Annotations;

namespace LeetCode._1305_All_Elements_in_Two_Binary_Search_Trees;

[PublicAPI]
public interface ISolution
{
    public IList<int> GetAllElements(TreeNode? root1, TreeNode? root2);
}
