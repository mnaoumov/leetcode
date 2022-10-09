namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

public interface ICodec
{
    // ReSharper disable once InconsistentNaming
    string serialize(TreeNode root);
    // ReSharper disable once InconsistentNaming
    TreeNode deserialize(string data);
}