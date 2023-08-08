using JetBrains.Annotations;

namespace LeetCode._0271_Encode_and_Decode_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/1015202483/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ICodec Create() => new Codec();

    private class Codec : ICodec
    {
        public string encode(IList<string> strs)
        {
            var maxLength = strs.Max(str => str.Length);
            var separator = new string(' ', maxLength + 1) + '\n';
            return string.Concat(strs.Select(str => separator + str));
        }

        public IList<string> decode(string s)
        {
            var separator = s.Split('\n')[0] + '\n';
            return s.Split(separator).Skip(1).ToArray();
        }
    }
}
