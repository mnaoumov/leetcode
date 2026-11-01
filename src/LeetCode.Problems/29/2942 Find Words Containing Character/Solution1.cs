namespace LeetCode.Problems._2942_Find_Words_Containing_Character;

/// <seealso href="https://leetcode.com/contest/biweekly-contest-118/submissions/detail/1106108718/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindWordsContaining(string[] words, char x) => Enumerable.Range(0, words.Length).Where(i => words[i].Contains(x)).ToArray();
}
