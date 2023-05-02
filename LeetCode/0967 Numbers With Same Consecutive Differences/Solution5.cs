using JetBrains.Annotations;

namespace LeetCode._0967_Numbers_With_Same_Consecutive_Differences;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] NumsSameConsecDiff(int n, int k)
    {
        var result = new List<int>();

        int num;
        for (var i = 1; i <= 9; i++)
        {
            num = i;
            Backtrack(1);
        }

        return result.ToArray();

        void Backtrack(int i)
        {
            if (i == n)
            {
                result.Add(num);
                return;
            }

            var lastDigit = num % 10;

            if (lastDigit >= k)
            {
                num = num * 10 + lastDigit - k;
                Backtrack(i + 1);
                num /= 10;
            }

            if (k == 0 || lastDigit > 9 - k)
            {
                return;
            }

            num = num * 10 + lastDigit + k;
            Backtrack(i + 1);
            num /= 10;
        }
    }
}
