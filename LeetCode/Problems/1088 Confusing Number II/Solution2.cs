using JetBrains.Annotations;

namespace LeetCode.Problems._1088_Confusing_Number_II;

/// <summary>
/// https://leetcode.com/submissions/detail/882736876/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ConfusingNumberII(int n)
    {
        var map = new Dictionary<int, int>
        {
            [0] = 0,
            [1] = 1,
            [6] = 9,
            [8] = 8,
            [9] = 6
        };

        var result = 0;

        AddDigits(0);

        return result;

        void AddDigits(int num)
        {
            foreach (var nextNum in map.Keys.Select(digit => (long) num * 10 + digit)
                         .Where(nextNumLong => nextNumLong != 0 && nextNumLong <= n)
                         .Select(nextNumLong => (int) nextNumLong))
            {
                if (IsConfusing(nextNum))
                {
                    result++;
                }

                AddDigits(nextNum);
            }
        }

        bool IsConfusing(int num)
        {
            var upsideDownNum = 0;

            var temp = num;

            while (temp > 0)
            {
                var digit = temp % 10;
                temp /= 10;
                upsideDownNum = upsideDownNum * 10 + map[digit];
            }

            return num != upsideDownNum;
        }
    }
}
