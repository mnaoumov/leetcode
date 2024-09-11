namespace LeetCode.Problems._0535_Encode_and_Decode_TinyURL;

[PublicAPI]
public interface ICodec
{
    // ReSharper disable InconsistentNaming
#pragma warning disable IDE1006
    public string encode(string longUrl);
    public string decode(string shortUrl);
#pragma warning restore IDE1006
    // ReSharper enable InconsistentNaming
}
