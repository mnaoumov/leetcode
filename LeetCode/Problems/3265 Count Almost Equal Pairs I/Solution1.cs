using JetBrains.Annotations;

namespace LeetCode.Problems._3265_Count_Almost_Equal_Pairs_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-412/submissions/detail/1367312841/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const int MaxNumber = 1_000_000;
    private readonly int _maxDigitsCount = MaxNumber.ToString().Length;

    public int CountPairs(int[] nums)
    {
        var n = nums.Length;

        var paddedStrs = nums.Select(num => num.ToString().PadLeft(_maxDigitsCount, '0')).ToArray();
        var paddedSortedStrs = paddedStrs.Select(str => string.Concat(str.OrderBy(c => c).ToArray())).ToArray();

        var ans = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (paddedSortedStrs[i] != paddedSortedStrs[j])
                {
                    continue;
                }

                var s1 = paddedStrs[i];
                var s2 = paddedStrs[j];

                if (s1 == s2)
                {
                    ans++;
                    continue;
                }

                var count = s1.Zip(s2, (digit1, digit2) => (digit1, digit2)).Count(x => x.digit1 != x.digit2);

                if (count == 2)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
