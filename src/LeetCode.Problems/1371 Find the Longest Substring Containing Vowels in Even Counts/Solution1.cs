namespace LeetCode.Problems._1371_Find_the_Longest_Substring_Containing_Vowels_in_Even_Counts;

/// <summary>
/// https://leetcode.com/submissions/detail/1390435670/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindTheLongestSubstring(string s)
    {
        var n = s.Length;
        var xorPrefixes = new int[n + 1];
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u' }.Select((letter, index) => (letter, index))
            .ToDictionary(x => x.letter, x => x.index);
        var xorMinIndexMap = new Dictionary<int, int> { [0] = 0 };
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var letter = s[i];

            xorPrefixes[i + 1] = !vowels.TryGetValue(letter, out var index)
                ? xorPrefixes[i]
                : xorPrefixes[i] ^ 1 << index;

            xorMinIndexMap.TryAdd(xorPrefixes[i + 1], i + 1);
            xorMinIndexMap[xorPrefixes[i + 1]] = Math.Min(xorMinIndexMap[xorPrefixes[i + 1]], i + 1);
            var previousIndex = xorMinIndexMap[xorPrefixes[i + 1]];
            ans = Math.Max(ans, i + 1 - previousIndex);
        }

        return ans;
    }
}
