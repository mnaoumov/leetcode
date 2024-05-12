using JetBrains.Annotations;

namespace LeetCode.Problems._1065_Index_Pairs_of_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/942693936/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] IndexPairs(string text, string[] words)
    {
        var wordsSet = words.ToHashSet();

        var list = new List<int[]>();

        for (var i = 0; i < text.Length; i++)
        {
            for (var j = i; j < text.Length; j++)
            {
                if (wordsSet.Contains(text[i..(j + 1)]))
                {
                    list.Add(new[] { i, j });
                }
            }
        }

        return list.ToArray();
    }
}
