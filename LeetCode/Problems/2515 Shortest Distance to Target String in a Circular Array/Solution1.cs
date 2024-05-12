using JetBrains.Annotations;

namespace LeetCode._2515_Shortest_Distance_to_Target_String_in_a_Circular_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/865476618/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ClosetTarget(string[] words, string target, int startIndex)
    {
        var result = int.MaxValue;

        for (var i = 0; i < words.Length; i++)
        {
            if (words[i] != target)
            {
                continue;
            }

            result = Math.Min(result, Math.Abs(i - startIndex));
            result = Math.Min(result, words.Length - Math.Abs(i - startIndex));
        }

        return result == int.MaxValue ? -1 : result;
    }
}
