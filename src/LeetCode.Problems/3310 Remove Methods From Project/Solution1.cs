namespace LeetCode.Problems._3310_Remove_Methods_From_Project;

/// <summary>
/// https://leetcode.com/problems/remove-methods-from-project/submissions/2097542629/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var reverseNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var invocation in invocations)
        {
            var a = invocation[0];
            var b = invocation[1];
            adjNodes[a].Add(b);
            reverseNodes[b].Add(a);
        }

        var suspiciousNodes = new HashSet<int>();

        MarkSuspiciousNode(k);

        var remainingNodes = Enumerable.Range(0, n).ToHashSet();

        foreach (var node in suspiciousNodes.Where(node => reverseNodes[node].All(suspiciousNodes.Contains)))
        {
            remainingNodes.Remove(node);
        }

        return remainingNodes.ToArray();

        void MarkSuspiciousNode(int node)
        {
            if (!suspiciousNodes.Add(node))
            {
                return;
            }

            foreach (var adjNode in adjNodes[node])
            {
                MarkSuspiciousNode(adjNode);
            }
        }
    }
}
