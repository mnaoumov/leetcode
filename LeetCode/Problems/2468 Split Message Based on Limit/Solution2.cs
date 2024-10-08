

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2468_Split_Message_Based_on_Limit;

/// <summary>
/// https://leetcode.com/problems/split-message-based-on-limit/submissions/844388231/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string[] SplitMessage(string message, int limit)
    {
        var n = GetPartsCount(message, limit);

        var result = new string[n];
        var textIndex = 0;

        for (var i = 1; i <= n; i++)
        {
            var suffix = $"<{i}/{n}>";
            var nextTextIndex = Math.Min(textIndex + limit - suffix.Length, message.Length);
            result[i - 1] = message[textIndex..nextTextIndex] + suffix;
            textIndex = nextTextIndex;
        }

        return result;
    }

    private static int GetPartsCount(string message, int limit)
    {
        var min = 1;
        var max = message.Length;

        while (min <= max)
        {
            var mid = (min + max) / 2;

            var n = mid;
            var p = Math.Floor(Math.Log10(n)) + 1;

            var totalSuffixesLength = (4 + p) * n;

            var counterLengthCount = 9;

            for (var counterLength = 1; counterLength <= p - 2; counterLength++)
            {
                totalSuffixesLength += counterLength * counterLengthCount;
                counterLengthCount *= 10;
            }

            totalSuffixesLength += (p - 1) * (n + 1 - Math.Pow(10, p - 1));

            var totalLength = totalSuffixesLength + message.Length;

            if (totalLength <= (n - 1) * limit)
            {
                max = mid - 1;
            }
            else if (totalLength > n * limit)
            {
                min = mid + 1;
            }
            else
            {
                return n;
            }
        }

        return 0;
    }
}
