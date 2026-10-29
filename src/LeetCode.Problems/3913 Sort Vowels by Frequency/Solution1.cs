using System.Text;

namespace LeetCode.Problems._3913_Sort_Vowels_by_Frequency;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-499/problems/sort-vowels-by-frequency/submissions/1988233502/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SortVowels(string s)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        var vowelIndices = new List<int>();
        var vowelCounts = new Dictionary<char, int>();
        var vowelFirstIndexMap = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];

            if (!vowels.Contains(letter))
            {
                continue;
            }

            vowelIndices.Add(i);
            vowelCounts.TryAdd(letter, 0);
            vowelCounts[letter]++;
            vowelFirstIndexMap.TryAdd(letter, i);
        }

        var sb = new StringBuilder(s);

        using var reorderedVowelsEnumerator = ReorderedVowels().GetEnumerator();
        reorderedVowelsEnumerator.MoveNext();


        foreach (var vowelIndex in vowelIndices)
        {
            sb[vowelIndex] = reorderedVowelsEnumerator.Current;
            reorderedVowelsEnumerator.MoveNext();
        }

        return sb.ToString();

        IEnumerable<char> ReorderedVowels()
        {
            var sortedVowels = vowelCounts.Keys.OrderByDescending(vowel => vowelCounts[vowel])
                .ThenBy(vowel => vowelFirstIndexMap[vowel]);

            foreach (var vowel in sortedVowels)
            {
                for (var i = 0; i < vowelCounts[vowel]; i++)
                {
                    yield return vowel;
                }
            }
        }
    }
}
