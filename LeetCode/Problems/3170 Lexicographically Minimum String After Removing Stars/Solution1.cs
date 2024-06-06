using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._3170_Lexicographically_Minimum_String_After_Removing_Stars;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-400/submissions/detail/1274851465/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ClearStars(string s)
    {
        const char star = '*';
        const char remove = ' ';
        var sb = new StringBuilder(s);
        var indicesPq = new PriorityQueue<int, (char letter, int reverseIndex)>();

        for (var i = 0; i < s.Length; i++)
        {
            var symbol = sb[i];

            if (symbol == star)
            {
                sb[i] = remove;
                sb[indicesPq.Dequeue()] = remove;
            }
            else
            {
                indicesPq.Enqueue(i, (sb[i], -i));
            }
        }

        for (var i = sb.Length - 1; i >= 0; i--)
        {
            if (sb[i] == remove)
            {
                sb.Remove(i, 1);
            }
        }

        return sb.ToString();
    }
}
