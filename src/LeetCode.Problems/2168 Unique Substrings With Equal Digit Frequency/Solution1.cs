namespace LeetCode.Problems._2168_Unique_Substrings_With_Equal_Digit_Frequency;

/// <summary>
/// https://leetcode.com/submissions/detail/1501276667/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EqualDigitFrequency(string s)
    {
        var n = s.Length;
        var prefixCounts = new int[n + 1, 10];

        for (var i = 0; i < n; i++)
        {
            for (var digit = 0; digit < 10; digit++)
            {
                prefixCounts[i + 1, digit] = prefixCounts[i, digit];
            }
            prefixCounts[i + 1, s[i] - '0']++;
        }

        var goodStrings = new HashSet<string>();

        for (var start = 0; start < n; start++)
        {
            for (var end = start + 1; end <= n; end++)
            {
                var commonCount = 0;
                var isGood = true;

                for (var digit = 0; digit < 10; digit++)
                {
                    var count = prefixCounts[end, digit] - prefixCounts[start, digit];

                    if (count == 0)
                    {
                        continue;
                    }

                    if (commonCount == 0)
                    {
                        commonCount = count;
                    }
                    else if (commonCount != count)
                    {
                        isGood = false;
                        break;
                    }
                }

                if (isGood)
                {
                    goodStrings.Add(s[start..end]);
                }
            }
        }

        return goodStrings.Count;
    }
}
