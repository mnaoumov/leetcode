using System.Text;

namespace LeetCode.Problems._3081_Replace_Question_Marks_in_String_to_Minimize_Its_Value;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-126/submissions/detail/1205386543/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string MinimizeStringValue(string s)
    {
        const char questionMark = '?';
        var sb = new StringBuilder(s);

        var counts = new int['z' - 'a' + 1];

        foreach (var letter in s.Where(letter => letter != questionMark))
        {
            IncreaseCount(letter);
        }

        var lettersQueue = new PriorityQueue<char, (int, char)>();

        for (var letter = 'a'; letter <= 'z'; letter++)
        {
            UpdateLettersQueue(letter);
        }

        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] != questionMark)
            {
                continue;
            }

            var minLetter = lettersQueue.Dequeue();
            sb[i] = minLetter;
            IncreaseCount(minLetter);
            UpdateLettersQueue(minLetter);
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
