namespace LeetCode.Problems._0271_Encode_and_Decode_Strings
{
    public interface ICodec
    {
        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006
        public string encode(IList<string> strs);
#pragma warning restore IDE1006

        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006
        // ReSharper disable once ReturnTypeCanBeEnumerable.Global
        public IList<string> decode(string s);
#pragma warning restore IDE1006
    }
}
