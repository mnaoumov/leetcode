using JetBrains.Annotations;

namespace LeetCode._2712_Minimum_Cost_to_Make_All_Characters_Equal;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinimumCost(string s) => Math.Min(MinimumCost(s, '0'), MinimumCost(s, '1'));

    private static long MinimumCost(string s, char desiredChar)
    {
        var i = 0;
        var j = s.Length - 1;

        var ans = 0L;

        while (true)
        {
            while (i <= j && s[i] == desiredChar)
            {
                i++;
            }

            while (i <= j && s[j] == desiredChar)
            {
                j--;
            }

            if (i > j)
            {
                break;
            }

            if (i == j)
            {
                ans += Math.Min(2 * i - 1, 2 * (s.Length - i) - 1);
                break;
            }
        }

        return ans;
    }
}
