namespace LeetCode.Problems._3900_Longest_Balanced_Substring_After_One_Swap;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-497/problems/longest-balanced-substring-after-one-swap/submissions/1975998322/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestBalanced(string s)
    {
        var n = s.Length;
        var oneCount = 0;
        var balanceEarliestIndices = new Dictionary<int, int> { [1] = -1 };
        var zeroIndices = new SortedSet<int>();
        var oneIndices = new SortedSet<int>();
        var hasZerosAfterIndices = new bool[n];
        var hasOnesAfterIndices = new bool[n];

        for (var i = n - 2; i >= 0; i--)
        {
            hasZerosAfterIndices[i] = hasZerosAfterIndices[i + 1] || s[i + 1] == '0';
            hasOnesAfterIndices[i] = hasOnesAfterIndices[i + 1] || s[i + 1] == '1';
        }

        var ans = 0;

        for (var j = 0; j < n; j++)
        {
            var isOne = s[j] == '1';

            oneCount += isOne ? 1 : 0;

            if (isOne)
            {
                oneIndices.Add(j);
            }
            else
            {
                zeroIndices.Add(j);
            }

            var balance = 2 * oneCount - j;
            balanceEarliestIndices.TryAdd(balance, j);

            if (balanceEarliestIndices.TryGetValue(balance, out var i))
            {
                ans = Math.Max(ans, j - i);
            }

            if (hasOnesAfterIndices[j] && balanceEarliestIndices.TryGetValue(balance + 2, out i) && zeroIndices.GetViewBetween(i, j).Count > 0)
            {
                ans = Math.Max(ans, j - i);
            }

            if (hasZerosAfterIndices[j] && balanceEarliestIndices.TryGetValue(balance - 2, out i) && oneIndices.GetViewBetween(i, j).Count > 0)
            {
                ans = Math.Max(ans, j - i);
            }
        }

        return ans;
    }
}
