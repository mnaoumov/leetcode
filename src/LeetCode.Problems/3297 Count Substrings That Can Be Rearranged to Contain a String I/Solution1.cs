namespace LeetCode.Problems._3297_Count_Substrings_That_Can_Be_Rearranged_to_Contain_a_String_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-416/submissions/detail/1398055811/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long ValidSubstringCount(string word1, string word2)
    {
        var letterCounts2 = word2.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        var ans = 0L;

        var startIndex = 0;
        var letterCounts1 = new Dictionary<char, int>();
        var missingLettersCount = word2.Length;

        for (var endIndex = 0; endIndex < word1.Length; endIndex++)
        {
            var letter = word1[endIndex];

            if (!letterCounts2.ContainsKey(letter))
            {
                continue;
            }

            letterCounts1.TryAdd(letter, 0);
            letterCounts1[letter]++;
            if (letterCounts1[letter] <= letterCounts2[letter])
            {
                missingLettersCount--;
            }

            while (missingLettersCount == 0)
            {
                ans += word1.Length - endIndex;

                var oldLetter = word1[startIndex];
                startIndex++;

                if (!letterCounts2.TryGetValue(oldLetter, out var charCount2))
                {
                    continue;
                }

                letterCounts1[oldLetter]--;

                if (letterCounts1[oldLetter] >= charCount2)
                {
                    continue;
                }

                missingLettersCount = 1;
            }
        }

        return ans;
    }
}
