namespace LeetCode.Problems._3332_Maximum_Points_Tourist_Can_Earn;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-142/submissions/detail/1434330172/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxScore(int n, int k, int[][] stayScore, int[][] travelScore)
    {
        var queue = new Queue<(int day, int city, int score)>();

        for (var city = 0; city < n; city++)
        {
            queue.Enqueue((0, city, 0));
        }

        var ans = 0;

        while (queue.Count > 0)
        {
            var (day, city, score) = queue.Dequeue();

            if (day == k)
            {
                ans = Math.Max(ans, score);
                continue;
            }

            for (var nextCity = 0; nextCity < n; nextCity++)
            {
                queue.Enqueue(nextCity == city
                    ? (day + 1, nextCity, score + stayScore[day][nextCity])
                    : (day + 1, nextCity, score + travelScore[city][nextCity]));
            }
        }

        return ans;
    }
}
