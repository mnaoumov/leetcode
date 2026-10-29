
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0421_Maximum_XOR_of_Two_Numbers_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/208463076/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaximumXOR(int[] nums)
    {
        const int maxPosition = 31;

        return FindMaximumXOR(maxPosition, nums, nums);
    }

    private static int FindMaximumXOR(int position, int[] numbers1, int[] numbers2)
    {
        if (!numbers1.Any() || !numbers2.Any())
        {
            return 0;
        }

        if (position < 0)
        {
            return numbers1[0] ^ numbers2[0];
        }

        var numbers1WithOneBit = numbers1.Where(n => HasOneBit(n, position)).ToArray();
        var numbers1WithZeroBit = numbers1.Where(n => !HasOneBit(n, position)).ToArray();
        var numbers2WithOneBit = numbers2.Where(n => HasOneBit(n, position)).ToArray();
        var numbers2WithZeroBit = numbers2.Where(n => !HasOneBit(n, position)).ToArray();

        int result = FindMaximumXOR(position - 1, numbers1WithOneBit, numbers2WithZeroBit);

        if (numbers1 != numbers2)
        {
            result = Math.Max(result, FindMaximumXOR(position - 1, numbers2WithOneBit, numbers1WithZeroBit));
        }

        if (result != 0)
        {
            return result;
        }

        return FindMaximumXOR(position - 1, numbers1, numbers2);
    }

    private static bool HasOneBit(int n, int position)
    {
        return ((n >> position) & 1) == 1;
    }
}
