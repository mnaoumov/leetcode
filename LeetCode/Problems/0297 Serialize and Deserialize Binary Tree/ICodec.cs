using JetBrains.Annotations;

namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

[PublicAPI]
public interface ICodec
{
#pragma warning disable IDE1006 // Naming Styles
    // ReSharper disable once InconsistentNaming
    string serialize(TreeNode? root);
    // ReSharper disable once InconsistentNaming
    TreeNode? deserialize(string data);
#pragma warning restore IDE1006 // Naming Styles
}
