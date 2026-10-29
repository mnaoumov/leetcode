namespace LeetCode.Problems._2581_Count_Number_of_Possible_Root_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/909068239/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int RootCount(int[][] edges, int[][] guesses, int k)
    {
        var n = edges.Length + 1;

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var guessCounts = new int[n];

        foreach (var guess in guesses)
        {
            var queue = new Queue<int>();
            queue.Enqueue(guess[0]);
            var seen = new HashSet<int> { guess[1] };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                guessCounts[node]++;
                seen.Add(node);

                foreach (var adjacentNode in adjacentNodes[node].Where(adjacentNode => !seen.Contains(adjacentNode)))
                {
                    queue.Enqueue(adjacentNode);
                }
            }
        }

        return guessCounts.Count(count => count >= k);
    }
}
