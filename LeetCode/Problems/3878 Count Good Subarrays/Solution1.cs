namespace LeetCode.Problems._3878_Count_Good_Subarrays;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long CountGoodSubarrays(int[] nums)
    {
        const int maxBit = 31;
        var bitCounts = new int[maxBit];
        var or = 0;
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
            var bitIndices = BitIndices(num);

            foreach (var bitIndex in bitIndices)
            {
                bitCounts[bitIndex]++;
            }

            or |= num;
            set.Add(num);
        }


        throw new NotImplementedException();
    }

    private static List<int> BitIndices(int num)
    {
        var ans = new List<int>();

        var bitIndex = 0;

        while (num > 0)
        {
            var lastBit = bitIndex & 1;

            if (lastBit == 1)
            {
                ans.Add(bitIndex);
            }
            num >>= 1;
            bitIndex++;
        }

        return ans;
    }
}
