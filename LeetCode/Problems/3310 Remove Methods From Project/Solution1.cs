namespace LeetCode.Problems._3310_Remove_Methods_From_Project;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public IList<int> RemainingMethods(int n, int k, int[][] invocations)
    {
        var invocationsMap = new Dictionary<int, List<int>>();

        foreach (var invocation in invocations)
        {
            var a = invocation[0];
            var b = invocation[1];
            invocationsMap.TryAdd(a, new List<int>());
            invocationsMap[a].Add(b);
        }

        var suspicious = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(k);
        while (queue.Count > 0)
        {
            var method = queue.Dequeue();
            if (!suspicious.Add(method))
            {
                continue;
            }

            foreach (var invokedMethod in invocationsMap[method])
            {
                queue.Enqueue(invokedMethod);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (suspicious.Contains(i))
            {
                continue;
            }
        }

        throw new NotImplementedException();
    }
}
