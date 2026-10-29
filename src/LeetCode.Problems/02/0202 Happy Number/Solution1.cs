namespace LeetCode.Problems._0202_Happy_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/925206237/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsHappy(int n)
    {
        var set = new HashSet<int>();

        while (true)
        {
            if (n == 1)
            {
                return true;
            }

            if (!set.Add(n))
            {
                return false;
            }

            n = Digits(n).Select(d => d * d).Sum();
        }
    }

    private static IEnumerable<int> Digits(int n)
    {
        while (n > 0)
        {
            yield return n % 10;
            n /= 10;
        }
    }
}
