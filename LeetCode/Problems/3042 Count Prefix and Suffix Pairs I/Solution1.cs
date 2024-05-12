using JetBrains.Annotations;

namespace LeetCode.Problems._3042_Count_Prefix_and_Suffix_Pairs_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-385/submissions/detail/1178391160/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        var n = words.Length;
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (isPrefixAndSuffix(words[i], words[j]))
                {
                    ans++;
                }
            }
        }

        return ans;
    }

    // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006
    private static bool isPrefixAndSuffix(string str1, string str2) => str2.StartsWith(str1) && str2.EndsWith(str1);
#pragma warning restore IDE1006
}
