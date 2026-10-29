namespace LeetCode.Problems._3090_Maximum_Length_Substring_With_Two_Occurrences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-390/submissions/detail/1212125287/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumLengthSubstring(string s)
    {
        var ans = 0;
        var i = 0;
        var counts = new Dictionary<char, int>();

        for (var j = 0; j < s.Length; j++)
        {
            var letter = s[j];
            counts.TryAdd(letter, 0);
            counts[letter]++;

            while (counts[letter] > 2)
            {
                var oldLetter = s[i];
                counts[oldLetter]--;
                i++;
            }

            ans = Math.Max(ans, j - i + 1);
        }

        return ans;
    }
}
