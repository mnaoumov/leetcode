using JetBrains.Annotations;

namespace LeetCode._2468_Split_Message_Based_on_Limit;

/// <summary>
/// https://leetcode.com/problems/split-message-based-on-limit/submissions/844911547/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public string[] SplitMessage(string message, int limit)
    {
        var n = GetPartsCount(message.Length, limit);
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

    private static int GetPartsCount(int length, int limit)
    {
        var result = 1;

        while (true)
        {
            var maxSuffixLength = 3 + 2 * GetNumberLength(result);

            if (maxSuffixLength >= limit)
            {
                return 0;
            }

            var suffixLengthAvailable = limit * result - length;
            var resultLength = GetNumberLength(result);

            var tensPower = 1;

            for (var partLength = 1; partLength < resultLength; partLength++)
            {
                var partsWithThisLengthCount = tensPower * 9;
                suffixLengthAvailable -= (3 + resultLength + partLength) * partsWithThisLengthCount;
                tensPower *= 10;

                if (suffixLengthAvailable < 0)
                {
                    break;
                }
            }

            suffixLengthAvailable -= (3 + resultLength + resultLength) * (result + 1 - tensPower);

            if (suffixLengthAvailable >= 0)
            {
                return result;
            }

            result++;
        }
    }

    private static int GetNumberLength(int number) => 1 + (int) Math.Floor(Math.Log10(number));
}
