namespace LeetCode._007_Reverse_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/148143853/
/// </summary>
public class OldSolution1 : ISolution
{
    public int Reverse(int x)
    {
        try
        {
            var sign = Math.Sign(x);
            x = Math.Abs(x);
            var result = 0;
            while (x > 0)
            {
                var lastDigit = x % 10;

                result = checked(result * 10 + lastDigit);
                x = x / 10;
            }

            result = result * sign;

            return result;

        }
        catch (OverflowException)
        {
            return 0;
        }
    }
}