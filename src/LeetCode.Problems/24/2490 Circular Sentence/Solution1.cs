namespace LeetCode.Problems._2490_Circular_Sentence;

/// <seealso href="https://leetcode.com/submissions/detail/854253715/">Submission</seealso>
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
