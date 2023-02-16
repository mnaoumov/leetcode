using JetBrains.Annotations;

namespace LeetCode._2429_Minimize_XOR;

/// <summary>
/// https://leetcode.com/submissions/detail/898855351/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimizeXor(int num1, int num2)
    {
        var bitsCount = GetOneBits(num2).Count();

        var result = 0;

        var oneBits = GetOneBits(num1).Reverse().ToArray();

        foreach (var position in oneBits.Reverse())
        {
            if (bitsCount == 0)
            {
                break;
            }

            result |= 1 << position;
            bitsCount--;
        }

        if (bitsCount == 0)
        {
            return result;
        }

        var oneBitsSet = oneBits.ToHashSet();

        for (var position = 0; position <= 31; position++)
        {
            if (oneBitsSet.Contains(position))
            {
                continue;
            }

            result |= 1 << position;
            bitsCount--;

            if (bitsCount == 0)
            {
                break;
            }
        }

        return result;
    }

    private static IEnumerable<int> GetOneBits(int num)
    {
        var position = 0;
        while (num > 0)
        {
            var bit = num & 1;

            if (bit == 1)
            {
                yield return position;
            }

            position++;
            num >>= 1;
        }
    }
}
