using JetBrains.Annotations;

namespace LeetCode.Problems._2389_Longest_Subsequence_With_Limited_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/865183202/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        var m = queries.Length;
        var n = nums.Length;
        var total = 0;
        var runningTotals = nums.OrderBy(num => num).Select(num => total += num).ToArray();

        var answers = new int[m];
        var runningTotalIndex = 0;
        foreach (var queryIndex in Enumerable.Range(0, m).OrderBy(index => queries[index]))
        {
            var query = queries[queryIndex];
            while (runningTotalIndex < n && query >= runningTotals[runningTotalIndex])
            {
                runningTotalIndex++;
            }
            answers[queryIndex] = runningTotalIndex;
        }
        return answers;
    }
}
