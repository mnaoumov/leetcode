using JetBrains.Annotations;

namespace LeetCode._0535_Encode_and_Decode_TinyURL;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ICodec Create()
    {
        return new Codec1();
    }
}
