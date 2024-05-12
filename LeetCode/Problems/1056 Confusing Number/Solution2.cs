using JetBrains.Annotations;

namespace LeetCode.Problems._1056_Confusing_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/875158343/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool ConfusingNumber(int n)
    {
        var digitsMap = new Dictionary<int, int>
        {
            [0] = 0,
            [1] = 1,
            [6] = 9,
            [8] = 8,
            [9] = 6
        };

        var upsideDownNum = 0;

        var temp = n;

        while (temp > 0)
        {
            var digit = temp % 10;
            temp /= 10;

            if (!digitsMap.TryGetValue(digit, out var upsideDownDigit))
            {
                return false;
            }

            upsideDownNum = upsideDownNum * 10 + upsideDownDigit;
        }

        return upsideDownNum != n;
    }
}
