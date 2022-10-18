using JetBrains.Annotations;

namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

[PublicAPI]
public interface ICodec
{
    // ReSharper disable once InconsistentNaming
    string serialize(TreeNode root);
    // ReSharper disable once InconsistentNaming
    TreeNode deserialize(string data);
}