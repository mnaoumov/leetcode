namespace LeetCode.Problems._2591_Distribute_Money_to_Maximum_Children;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-100/submissions/detail/917483206/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int DistMoney(int money, int children)
    {
        if (money < children)
        {
            return -1;
        }

        var result = Math.Min(children, (money - children) / 7);
        var childrenLeft = children - result;
        var moneyLeft = money - result * 8;

        if (childrenLeft == 0)
        {
            return moneyLeft == 0 ? result : result - 1;
        }

        if (moneyLeft < childrenLeft)
        {
            return result - 1;
        }

        if (moneyLeft == 4 && childrenLeft == 1)
        {
            return result - 1;
        }

        return result;
    }
}
