namespace LeetCode.Problems._3287_Find_the_Maximum_Sequence_Value_of_Array;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    private const int BitsCount = 31;


    public int MaxValue(int[] nums, int k)
    {
        var n = nums.Length;
        var m = n - k + 1;

        var orBitCounts = new int[m, BitsCount];

        for (var i = 0; i < n; i++)
        {
            var bits = ToBits(nums[i]);
            var l = Math.Max(i - k + 1, 0);
            for (var j = 0; j < BitsCount; j++)
            {
                orBitCounts[l, j] += bits[j];
            }

            if (i < k || k == 1)
            {
                continue;
            }

            var previousBits = ToBits(nums[i - k]);

            for (var j = 0; j < BitsCount; j++)
            {
                orBitCounts[l, j] -= previousBits[j];
            }
        }

        var ors = new int[m];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < BitsCount; j++)
            {
                ors[i] |= orBitCounts[i, j] << j;
            }
        }

        var low = 0;
        var high = int.MaxValue;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var found = false;
            for (var i = 0; i < m - k; i++)
            {
                for (var l = i + k; l < m; l++)
                {
                    var xor = ors[i] ^ ors[l];

                    if (xor < mid)
                    {
                        continue;
                    }

                    low = xor + 1;
                    found = true;
                }

                if (found)
                {
                    break;
                }
            }

            if (!found)
            {
                high = mid - 1;
            }
        }

        return high;
    }

    private static int[] ToBits(int num)
    {
        var bits = new int[BitsCount];

        for (var j = 0; j < BitsCount; j++)
        {
            bits[j] = num & 1;
            num >>= 1;

            if (num == 0)
            {
                break;
            }
        }

        return bits;
    }
}
