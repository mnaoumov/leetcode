namespace LeetCode.Problems._2802_Find_The_K_th_Lucky_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/1271009131/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string KthLuckyNumber(int k)
    {
        if (k == 0)
        {
            return "";
        }

        var l = (int) Math.Log2(k + 1);

        var firstDigit = k >= (1 << l) - 1 + (1 << l - 1) ? '7' : '4';
        return firstDigit + KthLuckyNumber(k - (1 << l - 1) * (firstDigit == '7' ? 2 : 1));
    }
}
