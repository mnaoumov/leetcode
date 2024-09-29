namespace LeetCode.Problems._3305_Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-417/submissions/detail/1405613087/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int CountOfSubstrings(string word, int k)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        const char consonant = 'c';
        var counts = new Dictionary<char, int>();

        foreach (var letter in vowels.Append(consonant))
        {
            counts[letter] = 0;
        }


        var ans = 0;
        var i = 0;

        for (var j = 0; j < word.Length; j++)
        {
            AddLetter(word[j]);

            while (counts[consonant] > k)
            {
                var letterToRemove = word[i];
                if (vowels.Contains(letterToRemove))
                {
                    counts[letterToRemove]--;
                }
                else
                {
                    counts[consonant]--;
                }

                i++;
            }

            if (!IsMatch())
            {
                continue;
            }

            while (i <= j && IsMatch())
            {
                ans++;

                var letterToRemove = word[i];

                if (vowels.Contains(letterToRemove))
                {
                    counts[letterToRemove]--;
                }
                else
                {
                    counts[consonant]--;
                }

                i++;
            }

            if (IsMatch())
            {
                continue;
            }

            i--;
            AddLetter(word[i]);
        }

        return ans;

        bool IsMatch() => counts[consonant] == k && vowels.All(vowel => counts[vowel] > 0);

        void AddLetter(char letter)
        {
            if (vowels.Contains(letter))
            {
                counts[letter]++;
            }
            else
            {
                counts[consonant]++;
            }
        }
    }
}
