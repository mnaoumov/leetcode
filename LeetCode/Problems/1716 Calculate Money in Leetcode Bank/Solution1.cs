using JetBrains.Annotations;

namespace LeetCode.Problems._1716_Calculate_Money_in_Leetcode_Bank;

/// <summary>
/// https://leetcode.com/submissions/detail/1113273439/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TotalMoney(int n)
    {
        var ans = 0;
        var dayMoney = 6;

        for (var day = 0; day < n; day++)
        {
            var isMonday = day % 7 == 0;

            if (isMonday)
            {
                dayMoney -= 5;
            }
            else
            {
                dayMoney++;
            }

            ans += dayMoney;
        }

        return ans;
    }
}
