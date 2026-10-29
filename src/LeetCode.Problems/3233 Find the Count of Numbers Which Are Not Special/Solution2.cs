namespace LeetCode.Problems._3233_Find_the_Count_of_Numbers_Which_Are_Not_Special;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-408/submissions/detail/1335677758/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NonSpecialCount(int l, int r)
    {
        var low = (int) Math.Ceiling(Math.Sqrt(l));
        var high = (int) Math.Floor(Math.Sqrt(r));
        var primesCount = Enumerable.Range(low, high - low + 1).Count(IsPrime);
        return r - l + 1 - primesCount;
    }

    private static bool IsPrime(int n)
    {
        if (n == 1)
        {
            return false;
        }

        var bound = (int) Math.Sqrt(n);

        for (var d = 2; d <= bound; d++)
        {
            if (n % d == 0)
            {
                return false;
            }
        }

        return true;
    }
}
