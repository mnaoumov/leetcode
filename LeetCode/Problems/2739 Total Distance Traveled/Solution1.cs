using JetBrains.Annotations;

namespace LeetCode.Problems._2739_Total_Distance_Traveled;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-350/submissions/detail/973681846/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistanceTraveled(int mainTank, int additionalTank)
    {
        var ans = 0;
        var counter = 0;

        while (mainTank > 0)
        {
            mainTank--;
            ans += 10;
            counter++;

            if (counter != 5 || additionalTank == 0)
            {
                continue;
            }

            counter = 0;
            additionalTank--;
            mainTank++;
        }

        return ans;
    }
}
