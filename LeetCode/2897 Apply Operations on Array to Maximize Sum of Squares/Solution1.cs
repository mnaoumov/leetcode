using JetBrains.Annotations;

namespace LeetCode._2897_Apply_Operations_on_Array_to_Maximize_Sum_of_Squares;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSum(IList<int> nums, int k)
    {
        var ordered = nums.OrderBy(num => num).ToArray();

        const int bitsCount = 30;
        var oneBitsIndices = Enumerable.Range(0, bitsCount).Select(_ => new SortedSet<int>()).ToArray();

        for (var i = 0; i < ordered.Length; i++)
        {
            var num = ordered[i];
            var bitIndex = 0;

            while (num > 0)
            {
                if ((num & 1) == 1)
                {
                    oneBitsIndices[bitIndex].Add(i);
                }

                num >>= 1;

                bitIndex++;
            }
        }

        return 0;
    }
}
