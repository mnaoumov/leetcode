using JetBrains.Annotations;

namespace LeetCode.Problems._0692_Top_K_Frequent_Words;

/// <summary>
/// https://leetcode.com/submissions/detail/826087379/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        var dict = new Dictionary<string, int>();

        foreach (var word in words)
        {
            dict.TryAdd(word, 0);

            dict[word]++;
        }

        var frequencyGroups = dict.GroupBy(kvp => kvp.Value, kvp => kvp.Key).OrderByDescending(frequency => frequency.Key);

        var result = new List<string>();

        foreach (var frequencyGroup in frequencyGroups)
        {
            result.AddRange(frequencyGroup.OrderBy(word => word));
            if (result.Count < k)
            {
                continue;
            }

            result.RemoveRange(k, result.Count - k);
            break;
        }

        return result;
    }
}
