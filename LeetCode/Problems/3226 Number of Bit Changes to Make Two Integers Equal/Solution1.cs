using JetBrains.Annotations;

namespace LeetCode.Problems._3226_Number_of_Bit_Changes_to_Make_Two_Integers_Equal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-407/submissions/detail/1327899777/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinChanges(int n, int k)
    {
        if ((n & k) != k)
        {
            return -1;
        }

        return CountBits(n ^ k);
    }

    private static int CountBits(int n)
    {
        var ans = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                ans++;
            }

            n >>= 1;
        }

        return ans;
    }
}
