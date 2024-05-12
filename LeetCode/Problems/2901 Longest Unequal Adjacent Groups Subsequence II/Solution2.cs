using JetBrains.Annotations;

namespace LeetCode.Problems._2901_Longest_Unequal_Adjacent_Groups_Subsequence_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-115/submissions/detail/1075059082/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<string> GetWordsInLongestSubsequence(int n, string[] words, int[] groups)
    {
        var sequences = Enumerable.Range(0, n).Select(_ => (previous: -1, length: 1)).ToArray();
        var maxLengthIndex = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (sequences[j].length + 1 <= sequences[i].length)
                {
                    continue;
                }

                if (groups[i] == groups[j])
                {
                    continue;
                }

                if (words[i].Length != words[j].Length)
                {
                    continue;
                }

                var distance = 0;

                for (var k = 0; k < words[i].Length; k++)
                {
                    if (words[i][k] == words[j][k])
                    {
                        continue;
                    }

                    distance++;

                    if (distance > 1)
                    {
                        break;
                    }
                }

                if (distance != 1)
                {
                    continue;
                }

                sequences[i] = (previous: j, length: sequences[j].length + 1);

                if (sequences[maxLengthIndex].length < sequences[i].length)
                {
                    maxLengthIndex = i;
                }
            }
        }

        var ans = new List<string>();
        var index = maxLengthIndex;

        while (index != -1)
        {
            ans.Insert(0, words[index]);
            index = sequences[index].previous;
        }

        return ans;
    }
}
