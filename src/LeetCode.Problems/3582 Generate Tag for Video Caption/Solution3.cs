namespace LeetCode.Problems._3582_Generate_Tag_for_Video_Caption;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-454/problems/generate-tag-for-video-caption/submissions/1664376059/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string GenerateTag(string caption)
    {
        var words = caption.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length == 0)
        {
            return "#";
        }
        words[0] = words[0].ToLowerInvariant();
        for (var i = 1; i < words.Length; i++)
        {
            var word = words[i];
            if (word.Length > 0)
            {
                words[i] = char.ToUpperInvariant(word[0]) + word[1..].ToLowerInvariant();
            }
        }
        var combined = string.Concat(words);
        var withHash = '#' + combined;
        const int maxLength = 100;
        var ans = withHash.Length > maxLength ? withHash[..maxLength] : withHash;
        return ans;
    }
}
