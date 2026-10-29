namespace LeetCode.Problems._2398_Maximum_Number_of_Robots_Within_Budget;

/// <summary>
/// https://leetcode.com/submissions/detail/904366443/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
    {
        var n = chargeTimes.Length;

        var low = 0;
        var high = n + 1;

        while (low < high)
        {
            var mid = low + (high - low >> 1);

            if (CanChoose(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return high - 1;

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
