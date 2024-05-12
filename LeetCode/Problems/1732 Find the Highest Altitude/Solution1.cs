using JetBrains.Annotations;

namespace LeetCode._1732_Find_the_Highest_Altitude;

/// <summary>
/// https://leetcode.com/submissions/detail/898920682/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestAltitude(int[] gain)
    {
        var n = gain.Length;
        var result = 0;
        var altitude = 0;

        for (var i = 0; i < n; i++)
        {
            altitude += gain[i];
            result = Math.Max(result, altitude);
        }

        return result;
    }
}
