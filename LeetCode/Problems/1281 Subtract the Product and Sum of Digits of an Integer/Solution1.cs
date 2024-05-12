using JetBrains.Annotations;

namespace LeetCode._1281_Subtract_the_Product_and_Sum_of_Digits_of_an_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/924018669/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SubtractProductAndSum(int n)
    {
        var product = 1;
        var sum = 0;

        while (n > 0)
        {
            var digit = n % 10;
            product *= digit;
            sum += digit;
            n /= 10;
        }

        return product - sum;
    }
}
