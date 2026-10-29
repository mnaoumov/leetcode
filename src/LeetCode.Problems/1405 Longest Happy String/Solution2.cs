using System.Text;

namespace LeetCode.Problems._1405_Longest_Happy_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1423779815/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

            if (sb.Length >= maxSequentialCount)
            {
                var haveToTakeNextLetter = true;

                for (var i = 1; i <= maxSequentialCount; i++)
                {
                    if (sb[^i] == letter)
                    {
                        continue;
                    }

                    haveToTakeNextLetter = false;
                    break;
                }

                if (haveToTakeNextLetter)
                {
                    if (pq.Count == 0)
                    {
                        break;
                    }

                    var (nextCount, nextLetter) = pq.Dequeue();
                    AddLetter(letter, count);
                    (count, letter) = (nextCount, nextLetter);
                }
            }

            sb.Append(letter);
            AddLetter(letter, count - 1);
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
