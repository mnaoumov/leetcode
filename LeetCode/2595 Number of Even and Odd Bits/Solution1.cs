using JetBrains.Annotations;

namespace LeetCode._2595_Number_of_Even_and_Odd_Bits;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-337/submissions/detail/917860339/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] EvenOddBit(int n)
    {
        var isEven = true;
        var even = 0;
        var odd = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                if (isEven)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }

            isEven = !isEven;
            n >>= 1;
        }

        return new[] { even, odd };
    }
}
