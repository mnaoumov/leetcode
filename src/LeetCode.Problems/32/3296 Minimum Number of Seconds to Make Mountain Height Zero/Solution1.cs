namespace LeetCode.Problems._3296_Minimum_Number_of_Seconds_to_Make_Mountain_Height_Zero;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-416/submissions/detail/1398025340/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        var pq = new PriorityQueue<(int workerIndex, int count), long>();

        for (var i = 0; i < workerTimes.Length; i++)
        {
            var workerTime = workerTimes[i];
            pq.Enqueue((i, 1), workerTime);
        }

        for (var i = 0; i < mountainHeight; i++)
        {
            var (workerIndex, count) = pq.Dequeue();
            var nextWorkTime = 1L * count * (count + 1) / 2 * workerTimes[workerIndex];
            pq.Enqueue((workerIndex, count + 1), nextWorkTime);

            if (i == mountainHeight - 1)
            {
                return nextWorkTime;
            }
        }

        throw new InvalidOperationException();
    }
}
