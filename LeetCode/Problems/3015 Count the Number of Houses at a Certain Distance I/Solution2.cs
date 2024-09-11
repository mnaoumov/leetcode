namespace LeetCode.Problems._3015_Count_the_Number_of_Houses_at_a_Certain_Distance_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-381/submissions/detail/1152165229/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] CountOfPairs(int n, int x, int y)
    {
        var visited = new bool[n + 1, n + 1];
        var checksLeft = n * (n - 1);
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

                if (end < 1 || end > n)
                {
                    continue;
                }

                if (visited[start, end])
                {
                    continue;
                }

                visited[start, end] = true;

                queue.Enqueue((start, end + 1));

                queue.Enqueue((start, end - 1));

                if (end == x)
                {
                    queue.Enqueue((start, y));
                }

                if (end == y)
                {
                    queue.Enqueue((start, x));
                }

                if (steps == 0)
                {
                    continue;
                }

                ans[steps - 1]++;
                checksLeft--;
            }

            steps++;
        }

        return ans;
    }
}
