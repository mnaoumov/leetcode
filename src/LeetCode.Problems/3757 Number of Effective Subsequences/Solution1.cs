namespace LeetCode.Problems._3757_Number_of_Effective_Subsequences;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int CountEffective(int[] nums)
    {
        const int maxBit = 31;
        var bitIndices = Enumerable.Range(0, maxBit + 1).Select(_ => new List<int>()).ToArray();

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];
            var bit = 0;
            var temp = num;

            while (temp > 0)
            {
                if ((temp & 1) == 1)
                {
                    bitIndices[bit].Add(index);
                }

                temp >>= 1;
                bit++;
            }
        }

        throw new NotImplementedException();
    }
}
