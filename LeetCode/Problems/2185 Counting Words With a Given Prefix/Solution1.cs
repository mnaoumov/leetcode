namespace LeetCode.Problems._2185_Counting_Words_With_a_Given_Prefix;

/// <summary>
/// https://leetcode.com/problems/counting-words-with-a-given-prefix/submissions/1502453753/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PrefixCount(string[] words, string pref) => words.Count(word => word.StartsWith(pref));
}
