using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._2437_Number_of_Valid_Clock_Times;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-89/submissions/detail/822997004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountTime(string time)
    {
        var hourStr = time[0..2];
        var minuteStr = time[3..5];

        return OptionsCount(hourStr, 24) * OptionsCount(minuteStr, 60);

        int OptionsCount(string pattern, int maxNumber)
        {
            var result = 0;
            for (var i = 0; i < maxNumber; i++)
            {
                var str = i.ToString("00");

                if (Matches(str, pattern))
                {
                    result++;
                }
            }

            return result;
        }

        bool Matches(string str, string pattern) => MatchesDigit(str[0], pattern[0]) && MatchesDigit(str[1], pattern[1]);
        bool MatchesDigit(char digit, char patternDigit) => digit == patternDigit || patternDigit == '?';
    }
}
