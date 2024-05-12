using JetBrains.Annotations;

namespace LeetCode.Problems._0297_Serialize_and_Deserialize_Binary_Tree;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ICodec Create()
    {
        return new Codec3();
    }
}
