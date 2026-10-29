namespace LeetCode.Problems._2520_Count_the_Digits_That_Divide_a_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/869788346/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountDigits(int num)
    {
        var result = 0;
        var x = num;

        while (x > 0)
        {
            var digit = x % 10;

            if (num % digit == 0)
            {
                result++;
            }

            x /= 10;
        }

        return result;
    }
}
