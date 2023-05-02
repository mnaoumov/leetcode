using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._1239_Maximum_Length_of_a_Concatenated_String_with_Unique_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/828999570/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxLength(IList<string> arr)
    {
        var dp = new Dictionary<string, HashSet<char>?>();

        return GetIndexCombinations(0).Select(indexCombination => GetCombinedCharacterSet(indexCombination, 0)?.Count ?? 0).Prepend(0).Max();

        IEnumerable<int[]> GetIndexCombinations(int index)
        {
            if (index >= arr.Count)
            {
                yield return Array.Empty<int>();
                yield break;
            }

            var nextCombinations = GetIndexCombinations(index + 1);

            foreach (var nextCombination in nextCombinations)
            {
                yield return nextCombination;
                yield return new[] { index }.Concat(nextCombination).ToArray();
            }
        }

        HashSet<char>? GetCombinedCharacterSet(int[] indexCombination, int subIndex)
        {
            var key = string.Join(" ", indexCombination.Skip(subIndex));

            if (!dp.ContainsKey(key))
            {
                dp[key] = Calculate();
            }

            return dp[key];

            HashSet<char>? Calculate()
            {
                if (subIndex >= indexCombination.Length)
                {
                    return new HashSet<char>();
                }

                var str = arr[indexCombination[subIndex]];
                var set = str.ToHashSet();

                if (set.Count != str.Length)
                {
                    return null;
                }

                var nextSet = GetCombinedCharacterSet(indexCombination, subIndex + 1);

                if (nextSet == null)
                {
                    return null;
                }

                set.UnionWith(nextSet);

                return set.Count - nextSet.Count != str.Length ? null : set;
            }
        }
    }
}
