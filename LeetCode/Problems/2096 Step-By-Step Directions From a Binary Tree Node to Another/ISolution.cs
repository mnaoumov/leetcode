using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2096_Step_By_Step_Directions_From_a_Binary_Tree_Node_to_Another;

[PublicAPI]
public interface ISolution
{
    public string GetDirections(TreeNode root, int startValue, int destValue);
}
