using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0072_Edit_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/820456180/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinDistance(string word1, string word2)
    {
        var dp = new int?[word1.Length + 1, word2.Length + 1];

        return Get(0, 0);

        int Get(int word1Index, int word2Index)
        {
            if (dp[word1Index, word2Index] is not { } result)
            {
                dp[word1Index, word2Index] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (word1Index == word1.Length)
                {
                    return word2.Length - word2Index;
                }

                if (word2Index == word2.Length)
                {
                    return word1.Length - word1Index;
                }

                return new[]
                {
                    1 + Get(word1Index + 1, word2Index),
                    1 + Get(word1Index, word2Index + 1),
                    (word1[word1Index] == word2[word2Index] ? 0 : 1) + Get(word1Index + 1, word2Index + 1)
                }.Min();
            }
        }
    }
}