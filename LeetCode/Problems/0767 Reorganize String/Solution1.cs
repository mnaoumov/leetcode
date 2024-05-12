using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0767_Reorganize_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1029137538/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReorganizeString(string s)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var pq = new PriorityQueue<char, int>();

        foreach (var (letter, count) in counts)
        {
            pq.Enqueue(letter, -count);
        }

        var sb = new StringBuilder();

        while (pq.Count > 0)
        {
            var letter = pq.Dequeue();

            if (sb.Length > 0)
            {
                var lastLetter = sb[^1];

                if (lastLetter == letter)
                {
                    if (pq.Count == 0)
                    {
                        return "";
                    }

                    var nextLetter = pq.Dequeue();
                    pq.Enqueue(letter, -counts[letter]);
                    letter = nextLetter;
                }
            }

            sb.Append(letter);
            counts[letter]--;

            if (counts[letter] > 0)
            {
                pq.Enqueue(letter, -counts[letter]);
            }
        }

        return sb.ToString();
    }
}
