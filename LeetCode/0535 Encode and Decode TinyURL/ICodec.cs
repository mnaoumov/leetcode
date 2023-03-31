using JetBrains.Annotations;

namespace LeetCode._0535_Encode_and_Decode_TinyURL;

[PublicAPI]
public interface ICodec
{
    public string encode(string longUrl);
    public string decode(string shortUrl);
}
