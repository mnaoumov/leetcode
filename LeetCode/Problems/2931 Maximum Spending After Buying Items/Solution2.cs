using JetBrains.Annotations;

namespace LeetCode.Problems._2931_Maximum_Spending_After_Buying_Items;

/// <summary>
/// https://leetcode.com/submissions/detail/1096662953/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxSpending(int[][] values)
    {
        var m = values.Length;
        var n = values[0].Length;

        var usedIndices = Enumerable.Repeat(n, m).ToArray();

        var ans = 0L;

        for (var d = 1; d <= m * n; d++)
        {
            var shopIndex = 0;
            var lowestPrice = int.MaxValue;

            for (var i = 0; i < m; i++)
            {
                if (usedIndices[i] == 0)
                {
                    continue;
                }

                if (values[i][usedIndices[i] - 1] >= lowestPrice)
                {
                    continue;
                }

                shopIndex = i;
                lowestPrice = values[i][usedIndices[i] - 1];
            }

            ans += 1L * lowestPrice * d;
            usedIndices[shopIndex]--;
        }

        return ans;
    }
}
