using JetBrains.Annotations;

namespace LeetCode._2490_Circular_Sentence;

/// <summary>
/// https://leetcode.com/submissions/detail/854253715/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsCircularSentence(string sentence)
    {
        var words = sentence.Split(' ');
        var n = words.Length;
        return Enumerable.Range(0, n).All(index => words[index][^1] == words[(index + 1) % n][0]);
    }
}