using JetBrains.Annotations;

namespace LeetCode._2960_Count_Tested_Devices_After_Test_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-375/submissions/detail/1116130913/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountTestedDevices(int[] batteryPercentages)
    {
        var ans = 0;

        foreach (var batteryPercentage in batteryPercentages)
        {
            if (batteryPercentage - ans > 0)
            {
                ans++;
            }
        }

        return ans;
    }
}
