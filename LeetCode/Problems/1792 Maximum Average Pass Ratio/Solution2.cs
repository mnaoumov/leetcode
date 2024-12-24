namespace LeetCode.Problems._1792_Maximum_Average_Pass_Ratio;

/// <summary>
/// https://leetcode.com/submissions/detail/1478986569/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        var pq = new PriorityQueue<(int pass, int total), double>();

        foreach (var @class in classes)
        {
            var pass = @class[0];
            var total = @class[1];
            pq.Enqueue((pass, total), -CalculateDiffCost(pass, total));
        }

        for (var i = 0; i < extraStudents; i++)
        {
            var (pass, total) = pq.Dequeue();
            pq.Enqueue((pass + 1, total + 1), -CalculateDiffCost(pass + 1, total + 1));
        }

        var sum = 0d;

        while (pq.Count > 0)
        {
            var (pass, total) = pq.Dequeue();
            sum += 1d * pass / total;
        }

        return sum / classes.Length;
    }

    private static double CalculateDiffCost(int pass, int total) => 1d * (total - pass) / (1d * total * (total + 1));
}
