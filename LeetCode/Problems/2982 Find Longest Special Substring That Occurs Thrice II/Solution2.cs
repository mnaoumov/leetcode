namespace LeetCode.Problems._2982_Find_Longest_Special_Substring_That_Occurs_Thrice_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-378/submissions/detail/1132666615/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaximumLength(string s)
    {
        var counts = new Dictionary<(char letter, int length), int>();

        var length = 0;
        var lastLetter = '\0';
        var ans = -1;

        foreach (var letter in s)
        {
            if (letter != lastLetter)
            {
                length = 1;
                lastLetter = letter;
            }
            else
            {
                length++;
            }

            if (length <= ans)
            {
                continue;
            }

            for (var subLength = length; subLength > Math.Max(ans, 0); subLength--)
            {
                var key = (letter, subLength);
                counts.TryAdd(key, 0);
                counts[key]++;

                if (counts[key] < 3)
                {
                    continue;
                }

                ans = subLength;
                break;
            }
        }

        return ans;
    }
}
