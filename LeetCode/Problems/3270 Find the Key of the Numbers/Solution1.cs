using JetBrains.Annotations;

namespace LeetCode.Problems._3270_Find_the_Key_of_the_Numbers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-138/submissions/detail/1374246578/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GenerateKey(int num1, int num2, int num3)
    {
        var ans = 0;
        var ansUnits = 1;

        while (num1 > 0 || num2 > 0 || num3 > 0)
        {
            var d1 = num1 % 10;
            var d2 = num2 % 10;
            var d3 = num3 % 10;

            var min = new[] { d1, d2, d3 }.Min();
            ans += ansUnits * min;

            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
            ansUnits *= 10;
        }

        return ans;
    }
}
