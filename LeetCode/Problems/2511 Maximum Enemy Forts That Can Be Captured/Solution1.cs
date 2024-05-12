using JetBrains.Annotations;

namespace LeetCode._2511_Maximum_Enemy_Forts_That_Can_Be_Captured;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-94/submissions/detail/864772592/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CaptureForts(int[] forts)
    {
        var start = 0;
        var result = 0;

        while (true)
        {
            while (start < forts.Length && forts[start] == 0)
            {
                start++;
            }

            if (start == forts.Length)
            {
                break;
            }

            var end = start + 1;

            while (end < forts.Length && forts[end] == 0)
            {
                end++;
            }

            if (end == forts.Length)
            {
                break;
            }

            if (forts[start] == -forts[end])
            {
                result = Math.Max(result, end - start - 1);
            }

            start = end;
        }

        return result;
    }
}
