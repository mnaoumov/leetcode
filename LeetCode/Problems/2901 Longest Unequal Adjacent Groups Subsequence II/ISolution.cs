using JetBrains.Annotations;

namespace LeetCode._2901_Longest_Unequal_Adjacent_Groups_Subsequence_II;

[PublicAPI]
public interface ISolution
{
    public IList<string> GetWordsInLongestSubsequence(int n, string[] words, int[] groups);
}
