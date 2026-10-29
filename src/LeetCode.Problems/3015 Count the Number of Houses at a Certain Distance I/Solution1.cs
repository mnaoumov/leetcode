namespace LeetCode.Problems._3015_Count_the_Number_of_Houses_at_a_Certain_Distance_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-381/submissions/detail/1152158939/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] CountOfPairs(int n, int x, int y)
    {
        var visited = new bool[n + 1, n + 1];
        var checksLeft = n * (n - 1) / 2;
        var ans = new int[n];

        var queue = new Queue<(int start, int end)>();

        for (var i = 1; i <= n; i++)
        {
            queue.Enqueue((i, i));
        }

        var steps = 0;

        while (checksLeft > 0)
        {
            var count = queue.Count;

            for (var j = 0; j < count; j++)
            {
                var (start, end) = queue.Dequeue();

                if (visited[start, end])
                {
                    continue;
                }

                visited[start, end] = true;

                if (end < n)
                {
                    queue.Enqueue((start, end + 1));
                }

                if (x != y && end == Math.Min(x, y))
                {
                    queue.Enqueue((start, Math.Max(x, y)));
                }

                if (steps == 0)
                {
                    continue;
                }

                ans[steps - 1] += 2;
                checksLeft--;
            }

            steps++;
        }

        return ans;
    }
}
