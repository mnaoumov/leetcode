using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable
#pragma warning disable CS8714

namespace LeetCode.Problems._1657_Determine_if_Two_Strings_Are_Close;

/// <summary>
/// https://leetcode.com/submissions/detail/853169856/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CloseStrings(string word1, string word2)
    {
        var countsMap1 = CountLetters(word1);
        var countsMap2 = CountLetters(word2);

        return AreEquivalent(countsMap1.Keys, countsMap2.Keys) && AreEquivalent(countsMap1.Values, countsMap2.Values);

        Dictionary<char, int> CountLetters(string word) => word.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        bool AreEquivalent<T>(IEnumerable<T> items1, IEnumerable<T> items2)
        {
            var enumerator1 = items1.GetEnumerator();
            var enumerator2 = items2.GetEnumerator();
            var diffMap = new Dictionary<T, int>();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                var value1 = enumerator1.Current;
                var value2 = enumerator2.Current;
                EnsureKeyExists(value1);
                EnsureKeyExists(value2);
                diffMap[value1]++;
                diffMap[value2]--;

                RemoveKeyIfZero(value1);
                RemoveKeyIfZero(value2);

                void EnsureKeyExists(T key)
                {
                    if (!diffMap.ContainsKey(key))
                    {
                        diffMap[key] = 0;
                    }
                }

                void RemoveKeyIfZero(T key)
                {
                    if (diffMap.ContainsKey(key) && diffMap[key] == 0)
                    {
                        diffMap.Remove(key);
                    }
                }
            }

            if (enumerator1.MoveNext() || enumerator2.MoveNext())
            {
                return false;
            }

            return diffMap.Count == 0;
        }
    }
}
