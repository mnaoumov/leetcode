namespace LeetCode.Problems._0860_Lemonade_Change;

/// <summary>
/// https://leetcode.com/submissions/detail/953698268/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool LemonadeChange(int[] bills)
    {
        var fiveDollarBills = 0;
        var tenDollarBills = 0;

        foreach (var bill in bills)
        {
            switch (bill)
            {
                case 5:
                    fiveDollarBills++;
                    break;
                case 10:
                    if (fiveDollarBills == 0)
                    {
                        return false;
                    }

                    tenDollarBills++;
                    fiveDollarBills--;
                    break;
                case 20:
                    if (fiveDollarBills == 0)
                    {
                        return false;
                    }

                    if (tenDollarBills > 0)
                    {
                        tenDollarBills--;
                        fiveDollarBills--;
                    } else if (fiveDollarBills < 3)
                    {
                        return false;
                    }
                    else
                    {
                        fiveDollarBills -= 3;
                    }
                    break;
            }
        }

        return true;
    }
}
