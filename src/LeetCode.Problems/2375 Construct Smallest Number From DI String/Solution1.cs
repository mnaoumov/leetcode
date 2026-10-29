using System.Text;

namespace LeetCode.Problems._2375_Construct_Smallest_Number_From_DI_String;

/// <summary>
/// https://leetcode.com/problems/construct-smallest-number-from-di-string/submissions/1548038152/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SmallestNumber(string pattern)
    {
        const char increasing = 'I';
        var n = pattern.Length;

        var usedDigits = new bool[10];
        var sb = new StringBuilder();
        Fill();
        return sb.ToString();

        bool Fill()
        {
            if (sb.Length == n + 1)
            {
                return true;
            }

            for (var digit = 1; digit <= 9; digit++)
            {
                if (usedDigits[digit])
                {
                    continue;
                }

                var previousDigit = sb.Length == 0 ? 0 : sb[^1] - '0';
                var isIncreasing = sb.Length == 0 || pattern[sb.Length - 1] == increasing;

                if (isIncreasing != digit > previousDigit)
                {
                    continue;
                }

                usedDigits[digit] = true;
                sb.Append(digit);

                if (Fill())
                {
                    return true;
                }

                usedDigits[digit] = false;
                sb.Remove(sb.Length - 1, 1);
            }

            return false;
        }
    }
}
