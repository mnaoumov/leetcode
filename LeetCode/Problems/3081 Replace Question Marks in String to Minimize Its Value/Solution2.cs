using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._3081_Replace_Question_Marks_in_String_to_Minimize_Its_Value;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-126/submissions/detail/1205398793/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string MinimizeStringValue(string s)
    {
        const char questionMark = '?';
        var sb = new StringBuilder(s);

        var counts = new int['z' - 'a' + 1];

        var questionMarkIndices = new List<int>();

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];

            if (letter == questionMark)
            {
                questionMarkIndices.Add(i);
            }
            else
            {
                IncreaseCount(letter);
            }
        }

        var lettersQueue = new PriorityQueue<char, (int, char)>();

        for (var letter = 'a'; letter <= 'z'; letter++)
        {
            UpdateLettersQueue(letter);
        }

        var replacementLetters = new List<char>();

        for (var i = 0; i < questionMarkIndices.Count; i++)
        {
            var minLetter = lettersQueue.Dequeue();
            replacementLetters.Add(minLetter);
            IncreaseCount(minLetter);
            UpdateLettersQueue(minLetter);
        }

        replacementLetters.Sort();

        for (var i = 0; i < questionMarkIndices.Count; i++)
        {
            sb[questionMarkIndices[i]] = replacementLetters[i];
        }

        return sb.ToString();

        void UpdateLettersQueue(char letter)
        {
            lettersQueue.Enqueue(letter, (counts[ToIndex(letter)], letter));
        }

        void IncreaseCount(char letter) => counts[ToIndex(letter)]++;

        int ToIndex(char letter) => letter - 'a';
    }
}
