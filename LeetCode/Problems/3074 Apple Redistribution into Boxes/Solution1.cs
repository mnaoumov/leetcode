using JetBrains.Annotations;

namespace LeetCode._3074_Apple_Redistribution_into_Boxes;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-388/submissions/detail/1199061433/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        capacity = capacity.OrderByDescending(x => x).ToArray();
        var applesLeft = apple.Sum();

        for (var i = 0; i < capacity.Length; i++)
        {
            applesLeft -= capacity[i];

            if (applesLeft <= 0)
            {
                return i + 1;
            }
        }

        throw new InvalidOperationException();
    }
}
