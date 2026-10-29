namespace LeetCode.Problems._1717_Maximum_Score_From_Removing_Substrings;

/// <summary>
/// https://leetcode.com/problems/maximum-score-from-removing-substrings/submissions/1707917095/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaximumGain(string s, int x, int y)
    {
        var pattern1 = "ab";
        var pattern2 = "ba";
        var gain1 = x;
        var gain2 = y;

        if (gain1 < gain2)
        {
            (pattern1, pattern2) = (pattern2, pattern1);
            (gain1, gain2) = (gain2, gain1);
        }

        var (replaceCount1, replacedString1) = RemovePattern(s, pattern1);
        var (replaceCount2, _) = RemovePattern(replacedString1, pattern2);

        return replaceCount1 * gain1 + replaceCount2 * gain2;
    }

    private static (int replaceCount, string replacedString) RemovePattern(string s, string pattern)
    {
        var stack = new Stack<char>();
        var replaceCount = 0;
        foreach (var letter in s)
        {
            if (letter == pattern[1] && stack.TryPeek(out var previousLetter) && previousLetter == pattern[0])
            {
                stack.Pop();
                replaceCount++;
            }
            else
            {
                stack.Push(letter);
            }
        }

        return (replaceCount, string.Concat(stack.Reverse()));
    }
}