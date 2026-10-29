namespace LeetCode.Problems._3805_Count_Caesar_Cipher_Pairs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-484/problems/count-caesar-cipher-pairs/submissions/1881268429/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountPairs(string[] words)
    {
        var groups = words.GroupBy(Normalize).ToArray();
        return groups.Select(g => g.Count()).Select(size => 1L * (size) * (size - 1) / 2).Sum();
    }

    private static string Normalize(string word)
    {
        var shift = word[0] - 'a';
        var chars = word.Select(c => (char)((c - 'a' - shift + 26) % 26 + 'a')).ToArray();
        return new string(chars);
    }
}
