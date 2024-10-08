namespace LeetCode.Problems._1624_Largest_Substring_Between_Two_Equal_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/1132580135/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        var firstIndices = new Dictionary<char, int>();
        var ans = -1;

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            firstIndices.TryAdd(letter, i);
            ans = Math.Max(ans, i - firstIndices[letter] - 1);
        }

        return ans;
    }
}
