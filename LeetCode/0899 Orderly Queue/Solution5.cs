using JetBrains.Annotations;

namespace LeetCode._0899_Orderly_Queue;

/// <summary>
/// https://leetcode.com/problems/orderly-queue/submissions/838280119/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public string OrderlyQueue(string s, int k)
    {
        if (k > 1)
        {
            return new string(s.OrderBy(x => x).ToArray());
        }

        var result = s;

        for (var i = 1; i < s.Length; i++)
        {
            var candidate = s[i..] + s[..i];

            if (string.Compare(candidate, result, StringComparison.Ordinal) < 0)
            {
                result = candidate;
            }
        }

        return result;
    }
}
