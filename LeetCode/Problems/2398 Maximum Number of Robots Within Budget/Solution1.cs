namespace LeetCode.Problems._2398_Maximum_Number_of_Robots_Within_Budget;

/// <summary>
/// https://leetcode.com/submissions/detail/904362031/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
    {
        var n = chargeTimes.Length;

        var low = 0;
        var high = n;

        while (low < high)
        {
            var mid = low + (high - low >> 1);

            if (CanChoose(mid))
            {
                low = mid;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;

        bool CanChoose(int k)
        {
            if (k == 0)
            {
                return true;
            }

            var runningCostSums = 0L;
            var chargeTimeMaxes = new LinkedList<int>();

            for (var i = 0; i < n; i++)
            {
                while (chargeTimeMaxes.Count > 0 && chargeTimeMaxes.Last!.Value < chargeTimes[i])
                {
                    chargeTimeMaxes.RemoveLast();
                }

                chargeTimeMaxes.AddLast(chargeTimes[i]);

                if (chargeTimeMaxes.Count > k)
                {
                    chargeTimeMaxes.RemoveFirst();
                }

                runningCostSums += runningCosts[i] - (i >= k ? runningCosts[i - k] : 0);

                if (i < k - 1)
                {
                    continue;
                }

                if (chargeTimeMaxes.Last!.Value + k * runningCostSums <= budget)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
