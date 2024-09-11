namespace LeetCode.Problems._0297_Serialize_and_Deserialize_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/875922654/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ICodec Create()
    {
        return new Codec3();
    }
}
