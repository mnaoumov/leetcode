namespace LeetCode.Problems._2275_Largest_Combination_With_Bitwise_AND_Greater_Than_Zero;

/// <seealso href="https://leetcode.com/submissions/detail/1445398608/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestCombination(int[] candidates)
    {
        const int bitCount = 32;
        var bitNumberCounts = new int[bitCount];

        foreach (var candidate in candidates)
        {
            var bit = 0;
            var temp = candidate;
            while (temp > 0)
            {
                if ((temp & 1) == 1)
                {
                    bitNumberCounts[bit]++;
                }

                temp >>= 1;
                bit++;
            }
        }

        return bitNumberCounts.Max();
    }
}
