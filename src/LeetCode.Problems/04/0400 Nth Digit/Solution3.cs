namespace LeetCode.Problems._0400_Nth_Digit;

/// <summary>
/// https://leetcode.com/submissions/detail/925489000/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int FindNthDigit(int n)
    {
        var digitsCount = 1;
        var groupSize = 9;
        var groupMin = 1;

        while (n > 1L * groupSize * digitsCount)
        {
            n -= groupSize * digitsCount;
            digitsCount++;
            groupSize *= 10;
            groupMin *= 10;
        }

        var numIndex = (n + digitsCount - 1) / digitsCount;
        var digitIndex = n - (numIndex - 1) * digitsCount;
        var num = groupMin - 1 + numIndex;

        for (var i = digitsCount; i > digitIndex; i--)
        {
            num /= 10;
        }

        return num % 10;
    }
}
