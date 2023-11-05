using JetBrains.Annotations;

namespace LeetCode._2925_Maximum_Score_After_Applying_Operations_on_a_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1091712573/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaximumScoreAfterOperations(int[][] edges, int[] values)
    {
        var n = edges.Length + 1;
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        return Dfs(0, -1).maxScore;

        (long subtreeSum, long maxScore) Dfs(int node, int parent)
        {
            var value = (long) values[node];

            if (adjNodes[node].Count == 1)
            {
                return (subtreeSum: value, maxScore: 0);
            }

            var totalChildSubtreeSum = 0L;
            var totalChildMaxScoreSum = 0L;

            foreach (var adjNode in adjNodes[node].Except(new[] { parent }))
            {
                var (childSubtreeSum, childMaxScore) = Dfs(adjNode, node);
                totalChildSubtreeSum += childSubtreeSum;
                totalChildMaxScoreSum += childMaxScore;
            }

            var maxScore = Math.Max(totalChildSubtreeSum, value + totalChildMaxScoreSum);
            return (subtreeSum: value + totalChildSubtreeSum, maxScore);
        }
    }
}
