namespace LeetCode.Problems._3714_Longest_Balanced_Substring_II;

/// <summary>
/// https://leetcode.com/problems/longest-balanced-substring-ii/submissions/1917599690/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestBalanced(string s)
    {
        var n = s.Length;
        var ans = 0;

        var countA = 0;
        var countB = 0;
        var countC = 0;
        var abIndices = new Dictionary<(int countA, int countB), int> { [(0, 0)] = -1 };
        var bcIndices = new Dictionary<(int countB, int countC), int> { [(0, 0)] = -1 };
        var caIndices = new Dictionary<(int countC, int countA), int> { [(0, 0)] = -1 };
        var aDiffBcIndices = new Dictionary<(int countA, int diffBC), int> { [(0, 0)] = -1 };
        var bDiffCaIndices = new Dictionary<(int countB, int diffCA), int> { [(0, 0)] = -1 };
        var cDiffAbIndices = new Dictionary<(int countC, int diffAB), int> { [(0, 0)] = -1 };
        var diffAbDiffBcIndices = new Dictionary<(int diffAB, int diffBC), int> { [(0, 0)] = -1 };

        for (var i = 0; i < n; i++)
        {
            switch (s[i])
            {
                case 'a':
                    countA++;
                    break;
                case 'b':
                    countB++;
                    break;
                case 'c':
                    countC++;
                    break;
            }

            if (abIndices.TryGetValue((countA, countB), out var abIndex))
            {
                ans = Math.Max(ans, i - abIndex);
            }

            if (bcIndices.TryGetValue((countB, countC), out var bcIndex))
            {
                ans = Math.Max(ans, i - bcIndex);
            }

            if (caIndices.TryGetValue((countC, countA), out var caIndex))
            {
                ans = Math.Max(ans, i - caIndex);
            }

            var diffBc = countB - countC;
            var diffCa = countC - countA;
            var diffAb = countA - countB;

            if (aDiffBcIndices.TryGetValue((countA, diffBc), out var aDiffBcIndex))
            {
                ans = Math.Max(ans, i - aDiffBcIndex);
            }

            if (bDiffCaIndices.TryGetValue((countB, diffCa), out var bDiffCaIndex))
            {
                ans = Math.Max(ans, i - bDiffCaIndex);
            }

            if (cDiffAbIndices.TryGetValue((countC, diffAb), out var cDiffAbIndex))
            {
                ans = Math.Max(ans, i - cDiffAbIndex);
            }

            if (diffAbDiffBcIndices.TryGetValue((diffAb, diffBc), out var diffAbDiffBcIndex))
            {
                ans = Math.Max(ans, i - diffAbDiffBcIndex);
            }

            abIndices.TryAdd((countA, countB), i);
            bcIndices.TryAdd((countB, countC), i);
            caIndices.TryAdd((countC, countA), i);
            aDiffBcIndices.TryAdd((countA, diffBc), i);
            bDiffCaIndices.TryAdd((countB, diffCa), i);
            cDiffAbIndices.TryAdd((countC, diffAb), i);
            diffAbDiffBcIndices.TryAdd((diffAb, diffBc), i);
        }

        return ans;
    }
}
