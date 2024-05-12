using JetBrains.Annotations;

namespace LeetCode._3035_Maximum_Palindromes_After_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1171919800/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxPalindromesAfterOperations(string[] words)
    {
        var counts = words.SelectMany(letter => letter).GroupBy(letter => letter).Select(g => g.Count()).ToArray();

        var pairsCount = counts.Sum(count => count / 2);
        var singleCounts = counts.Sum(count => count % 2);
        var lengths = words.Select(word => word.Length).OrderBy(length => length).ToArray();
        var ans = 0;

        foreach (var length in lengths)
        {
            if (length % 2 == 0)
            {
                if (pairsCount < length / 2)
                {
                    continue;
                }

                ans++;
                pairsCount -= length / 2;
            }
            else
            {
                if (singleCounts == 0 && pairsCount > 0)
                {
                    singleCounts += 2;
                    pairsCount--;
                }

                if (singleCounts == 0 || pairsCount < length / 2)
                {
                    continue;
                }

                ans++;
                singleCounts--;
                pairsCount -= length / 2;
            }
        }

        return ans;
    }
}
