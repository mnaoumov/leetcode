namespace LeetCode.Problems._0953_Verifying_an_Alien_Dictionary;

/// <summary>
/// https://leetcode.com/submissions/detail/890233489/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var letterIndexMap = order.Select((letter, index) => (letter, index)).ToDictionary(x => x.letter, x => x.index);

        for (var i = 0; i < words.Length - 1; i++)
        {
            var word1 = words[i];
            var word2 = words[i + 1];

            if (!AreWordsOrdered(word1, word2))
            {
                return false;
            }
        }

        return true;

        bool AreWordsOrdered(string word1, string word2)
        {
            if (word1 == word2)
            {
                return true;
            }

            for (var j = 0; j < Math.Min(word1.Length, word2.Length); j++)
            {
                var letter1 = word1[j];
                var letter2 = word2[j];
                var index1 = letterIndexMap[letter1];
                var index2 = letterIndexMap[letter2];

                if (index1 > index2)
                {
                    return false;
                }

                if (index1 < index2)
                {
                    return true;
                }
            }

            return word1.Length < word2.Length;
        }
    }
}
