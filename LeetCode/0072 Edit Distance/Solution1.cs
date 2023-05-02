using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0072_Edit_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/197096186/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDistance(string word1, string word2)
    {
        var prefixesCache = new int[word1.Length + 1, word2.Length + 1];

        for (int i = 0; i <= word1.Length; i++)
        {
            for (int j = 0; j <= word2.Length; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }

                var distanceCandidates = new List<int>();

                if (i > 0)
                {
                    distanceCandidates.Add(prefixesCache[i - 1, j] + 1);
                }

                if (j > 0)
                {
                    distanceCandidates.Add(prefixesCache[i, j - 1] + 1);
                }

                if (i > 0 && j > 0)
                {
                    var replacementRequired = word1[i - 1] != word2[j - 1];
                    distanceCandidates.Add(prefixesCache[i - 1, j - 1] + (replacementRequired ? 1 : 0));
                }

                prefixesCache[i, j] = distanceCandidates.Min();
            }
        }

        return prefixesCache[word1.Length, word2.Length];
    }
}
