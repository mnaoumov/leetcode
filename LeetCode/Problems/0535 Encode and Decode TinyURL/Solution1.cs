using JetBrains.Annotations;

namespace LeetCode._0535_Encode_and_Decode_TinyURL;

/// <summary>
/// https://leetcode.com/submissions/detail/925497116/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ICodec Create() => new Codec();

    private class Codec : ICodec
    {
        public string encode(string longUrl) => longUrl;
        public string decode(string shortUrl) => shortUrl;
    }
}
