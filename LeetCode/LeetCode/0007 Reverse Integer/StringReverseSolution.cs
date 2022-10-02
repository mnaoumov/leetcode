namespace LeetCode._0007_Reverse_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/807857883/
/// </summary>
public class StringReverseSolution : ISolution
{
    public int Reverse(int x)
    {
        if (x == int.MinValue)
        {
            return 0;
        }

        var sign = 1;

        if (x < 0)
        {
            x = -x;
            sign = -1;
        }

        var reverseStr = new string(x.ToString().ToCharArray().Reverse().ToArray());

        if (int.TryParse(reverseStr, out var result))
        {
            return sign * result;
        }

        return 0;
    }
}