using JetBrains.Annotations;

namespace LeetCode._1055_Shortest_Way_to_Form_String;

/// <summary>
/// https://leetcode.com/submissions/detail/911193523/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShortestWay(string source, string target)
    {
        var letterIndicesMap = source.Select((letter, index) => (letter, index)).GroupBy(x => x.letter, x => x.index).ToDictionary(g => g.Key, g => g.OrderBy(x => x).ToArray());
        var result = 1;
        var lastIndex = -1;
        foreach (var letter in target)
        {
            if (!letterIndicesMap.ContainsKey(letter))
            {
                return -1;
            }

            var indices = letterIndicesMap[letter];
            var indexOfIndex = Array.BinarySearch(indices, lastIndex + 1);
            if (indexOfIndex < 0)
            {
                indexOfIndex = ~indexOfIndex;
            }

            if (indexOfIndex == indices.Length)
            {
                indexOfIndex = 0;
                result++;
            }

            lastIndex = indices[indexOfIndex];
        }
        return result;
    }
}
