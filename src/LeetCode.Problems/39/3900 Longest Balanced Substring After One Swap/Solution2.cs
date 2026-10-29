namespace LeetCode.Problems._3900_Longest_Balanced_Substring_After_One_Swap;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestBalanced(string s)
    {
        var n = s.Length;
        var oneCount = 0;
        var balanceEarliestIndices = new Dictionary<int, int> { [1] = -1 };
        var zeroIndices = new SortedSet<int>();
        var oneIndices = new SortedSet<int>();

        for (var j = 0; j < n; j++)
        {
            var isOne = s[j] == '1';
            if (isOne)
            {
                oneIndices.Add(j);
            }
            else
            {
                zeroIndices.Add(j);
            }
        }

        var ans = 0;

        for (var j = 0; j < n; j++)
        {
            var isOne = s[j] == '1';

            oneCount += isOne ? 1 : 0;

            var balance = 2 * oneCount - j;
            balanceEarliestIndices.TryAdd(balance, j);

            if (balanceEarliestIndices.TryGetValue(balance, out var i))
            {
                ans = Math.Max(ans, j - i);
            }

            if (
                balanceEarliestIndices.TryGetValue(balance + 2, out i)
                && (
                    (zeroIndices.GetViewBetween(i, j).Count > 0
                    && oneIndices.GetViewBetween(j + 1, n).Count > 0
                    )
                    || (
                        oneIndices.GetViewBetween(i, j).Count > 0
                        && zeroIndices.GetViewBetween(-2, i - 1).Count > 0
                        )
                    )
                )
            {
                ans = Math.Max(ans, j - i);
            }

            if (
                balanceEarliestIndices.TryGetValue(balance - 2, out i)
                && (
                    (oneIndices.GetViewBetween(i, j).Count > 0
                     && zeroIndices.GetViewBetween(j + 1, n).Count > 0
                    )
                    || (
                        zeroIndices.GetViewBetween(i, j).Count > 0
                        && oneIndices.GetViewBetween(-2, i - 1).Count > 0
                    )
                )
            )
            {
                ans = Math.Max(ans, j - i);
            }
        }

        return ans;
    }
}
