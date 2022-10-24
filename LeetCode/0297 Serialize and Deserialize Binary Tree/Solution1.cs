using JetBrains.Annotations;

namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/199799092/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ICodec Create()
    {
        return new Codec1();
    }
}