namespace LeetCode.Problems._1455_Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence;

/// <summary>
/// https://leetcode.com/submissions/detail/1467940024/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(' ');

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];

            if (word.StartsWith(searchWord))
            {
                return i + 1;
            }
        }

        return -1;
    }
}
