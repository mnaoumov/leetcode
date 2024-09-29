namespace LeetCode.Problems._3305_Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-417/submissions/detail/1405638414/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int CountOfSubstrings(string word, int k)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        const char consonant = 'c';
        var letterToIndexMap = vowels.Append(consonant).Select((letter, index) => (letter, index)).ToDictionary(x => x.letter, x => x.index);
        var n = word.Length;
        var prefixCounts = new int[n + 1, vowels.Count + 1];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < vowels.Count + 1; j++)
            {
                prefixCounts[i + 1, j] = prefixCounts[i, j];
            }

            var letter = word[i];
            if (!vowels.Contains(letter))
            {
                letter = consonant;
            }
            var letterIndex = letterToIndexMap[letter];

            prefixCounts[i + 1, letterIndex]++;
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                if (GetCounts(i, j, consonant) == k && vowels.All(vowel => GetCounts(i, j, vowel) > 0))
                {
                    ans++;
                }
                
            }
        }

        return ans;

        int GetCounts(int i, int j, char letter)
        {
            var letterIndex = letterToIndexMap[letter];
            return prefixCounts[j + 1, letterIndex] - prefixCounts[i, letterIndex];
        }
    }
}
