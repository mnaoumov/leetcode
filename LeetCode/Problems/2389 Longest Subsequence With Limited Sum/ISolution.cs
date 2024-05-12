using JetBrains.Annotations;

namespace LeetCode._2389_Longest_Subsequence_With_Limited_Sum;

[PublicAPI]
public interface ISolution
{
    public int[] AnswerQueries(int[] nums, int[] queries);
}
