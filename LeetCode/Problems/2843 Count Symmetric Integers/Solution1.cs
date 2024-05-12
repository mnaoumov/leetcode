using JetBrains.Annotations;

namespace LeetCode._2843_Count_Symmetric_Integers;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-361/submissions/detail/1038992343/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountSymmetricIntegers(int low, int high)
    {
        var ans = 0;

        for (var i = low; i <= high; i++)
        {
            var digits = GetDigits(i);

            var m = digits.Count;

            if (m % 2 == 1)
            {
                continue;
            }

            var n = m / 2;

            if (digits.Take(n).Sum() == digits.Skip(n).Take(n).Sum())
            {
                ans++;
            }
        }

        return ans;
    }

    private static IList<int> GetDigits(int num)
    {
        var list = new List<int>();

        while (num > 0)
        {
            list.Insert(0, num % 10);
            num /= 10;
        }

        return list;
    }
}
