using JetBrains.Annotations;

namespace LeetCode.Problems._3154_Find_Number_of_Ways_to_Reach_the_K_th_Stair;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-398/submissions/detail/1261839746/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int WaysToReachStair(int k)
    {
        var queue = new Queue<(int step, int jump, bool goDownUsed)>();
        queue.Enqueue((1, 0, false));
        var ans = 0;

        while (queue.Count > 0)
        {
            var (step, jump, goDownUsed) = queue.Dequeue();

            if (step == k)
            {
                ans++;
            }

            if (step > 0 && !goDownUsed)
            {
                queue.Enqueue((step - 1, jump, true));
            }

            var nextStep = step + (1 << jump);

            if (nextStep <= k + 1)
            {
                queue.Enqueue((nextStep, jump + 1, false));
            }
        }

        return ans;
    }
}
