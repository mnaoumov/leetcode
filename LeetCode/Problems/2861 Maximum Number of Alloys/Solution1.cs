namespace LeetCode.Problems._2861_Maximum_Number_of_Alloys;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-363/submissions/detail/1051433804/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost)
    {
        var low = 0;
        var high = int.MaxValue;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanBuildAlloys(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanBuildAlloys(int alloysCount)
        {
            for (var i = 0; i < k; i++)
            {
                var budgetLeft = 0L + budget;
                var canBuy = true;

                for (var j = 0; j < n; j++)
                {
                    var requiredUnitsCount = 1L * composition[i][j] * alloysCount - stock[j];
                    budgetLeft -= requiredUnitsCount * cost[j];

                    if (budgetLeft >= 0)
                    {
                        continue;
                    }

                    canBuy = false;
                    break;
                }

                if (canBuy)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
