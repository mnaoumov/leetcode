using JetBrains.Annotations;

namespace LeetCode.Problems._1325_Delete_Leaves_With_a_Given_Value;

[PublicAPI]
public interface ISolution
{
    public TreeNode RemoveLeafNodes(TreeNode root, int target);
}
