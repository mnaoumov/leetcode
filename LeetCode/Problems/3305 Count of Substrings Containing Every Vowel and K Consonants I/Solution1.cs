namespace LeetCode.Problems._3305_Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-417/submissions/detail/1405565754/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

        foreach (var letter in word)
        {
            if (vowels.Contains(letter))
            {
                counts[letter]++;
            }
            else
            {
                counts[consonant]++;
            }

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

            if (counts[consonant] == k && vowels.All(vowel => counts[vowel] > 0))
            {
                ans++;
            }
        }

        return ans;
    }
}
