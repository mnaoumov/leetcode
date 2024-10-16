using System.Text;

namespace LeetCode.Problems._1405_Longest_Happy_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1423774591/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string LongestDiverseString(int a, int b, int c)
    {
        var pq = new PriorityQueue<(int count, char letter), int>();
        AddLetter('a', a);
        AddLetter('b', b);
        AddLetter('c', c);
        const int maxSequentialCount = 2;

        var sb = new StringBuilder();

        while (pq.Count > 0)
        {
            var (count, letter) = pq.Dequeue();

            if (sb.Length > 0 && sb[^1] == letter)
            {
                if (pq.Count == 0)
                {
                    break;
                }

                var (nextCount, nextLetter) = pq.Dequeue();
                AddLetter(letter, count);
                (count, letter) = (nextCount, nextLetter);
            }

            var takenCount = Math.Min(count, maxSequentialCount);
            sb.Append(letter, takenCount);
            AddLetter(letter, count - takenCount);
        }

        return sb.ToString();

        void AddLetter(char letter, int count)
        {
            if (count > 0)
            {
                pq.Enqueue((count, letter), -count);
            }
        }
    }
}
