using System.Text;

namespace LeetCode.Problems._2182_Construct_String_With_Repeat_Limit;

/// <summary>
/// https://leetcode.com/submissions/detail/908432666/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var sb = new StringBuilder();
        var heap = new PriorityQueue<char, int>();

        foreach (var letter in counts.Keys)
        {
            heap.Enqueue(letter, -letter);
        }

        while (heap.Count > 0)
        {
            var maxLetter = heap.Dequeue();
            var count = Math.Min(repeatLimit, counts[maxLetter]);
            sb.Append(maxLetter, count);
            counts[maxLetter] -= count;

            if (counts[maxLetter] == 0)
            {
                continue;
            }

            if (heap.Count == 0)
            {
                break;
            }

            var nextLetter = heap.Dequeue();
            sb.Append(nextLetter);
            counts[nextLetter]--;

            if (counts[nextLetter] > 0)
            {
                heap.Enqueue(nextLetter, -nextLetter);
            }

            heap.Enqueue(maxLetter, -maxLetter);
        }

        return sb.ToString();
    }
}
