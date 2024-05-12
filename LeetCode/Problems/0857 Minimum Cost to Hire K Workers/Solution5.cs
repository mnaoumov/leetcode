using JetBrains.Annotations;

namespace LeetCode.Problems._0857_Minimum_Cost_to_Hire_K_Workers;

/// <summary>
/// https://leetcode.com/submissions/detail/1255807956/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        var n = quality.Length;
        var workers = Enumerable.Range(0, n).Select(index => new Worker(quality[index], wage[index])).OrderBy(w => w.WageQualityRatio).ToArray();

        var pq = new PriorityQueue<Worker, int>();
        var ans = double.PositiveInfinity;

        var totalQuality = 0;

        foreach (var worker in workers)
        {
            pq.Enqueue(worker, -worker.Quality);
            totalQuality += worker.Quality;

            if (pq.Count > k)
            {
                var removedWorker = pq.Dequeue();
                totalQuality -= removedWorker.Quality;
            }

            if (pq.Count == k)
            {
                ans = Math.Min(ans, totalQuality * worker.WageQualityRatio);
            }
        }

        return ans;
    }

    private record Worker(int Quality, int Wage)
    {
        public double WageQualityRatio => 1d * Wage / Quality;
    }
}
