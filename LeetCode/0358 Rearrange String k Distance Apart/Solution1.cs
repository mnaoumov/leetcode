using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0358_Rearrange_String_k_Distance_Apart;

/// <summary>
/// https://leetcode.com/submissions/detail/956877214/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RearrangeString(string s, int k)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        var lettersPq = new PriorityQueue<char, int>();

        foreach (var (letter, count) in counts)
        {
            lettersPq.Enqueue(letter, -count);
        }

        var sb = new StringBuilder();

        var waitQueue = new Queue<char>();

        while (lettersPq.Count > 0)
        {
            var letter = lettersPq.Dequeue();
            sb.Append(letter);
            counts[letter]--;

            waitQueue.Enqueue(letter);

            if (waitQueue.Count < k)
            {
                continue;
            }

            var newAvailableLetter = waitQueue.Dequeue();

            if (counts[newAvailableLetter] > 0)
            {
                lettersPq.Enqueue(newAvailableLetter, -counts[newAvailableLetter]);
            }
        }

        return sb.Length < s.Length ? "" : sb.ToString();
    }
}
