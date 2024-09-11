using System.Text;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3267_Count_Almost_Equal_Pairs_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-412/submissions/detail/1367399471/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    private const int MaxNumber = 10_000_000 - 1;
    private static readonly int MaxDigitsCount = MaxNumber.ToString().Length;

    public int CountPairs(int[] nums)
    {
        var n = nums.Length;

        var paddedStrs = nums.Select(num => Pad(num.ToString())).ToArray();
        var paddedSortedStrs = paddedStrs.Select(str => string.Concat(str.OrderBy(c => c).ToArray())).ToArray();
        var swapSets = nums.Select(GetSwapSet).ToArray();

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

                if (swapSets[i].Overlaps(swapSets[j]))
                {
                    ans++;
                }
            }
        }

        return ans;
    }

    private static string Pad(string str) => str.PadLeft(MaxDigitsCount, '0');

    private static HashSet<string> GetSwapSet(int num)
    {
        var sb = new StringBuilder(num.ToString());
        var ans = new HashSet<string> { Pad(sb.ToString()) };
        var n = sb.Length;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (sb[i] == sb[j])
                {
                    continue;
                }

                (sb[i], sb[j]) = (sb[j], sb[i]);
                ans.Add(Pad(sb.ToString()));
                (sb[i], sb[j]) = (sb[j], sb[i]);
            }
        }

        return ans;
    }
}
