using JetBrains.Annotations;

namespace LeetCode._0854_K_Similar_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/886392331/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int KSimilarity(string s1, string s2)
    {
        var possibleLetters = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var letterIndexMap1 = possibleLetters.ToDictionary(letter => letter, _ => new List<int>());

        var n = s1.Length;

        var visited = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            var letter1 = s1[i];
            var letter2 = s2[i];

            if (letter1 == letter2)
            {
                visited.Add(i);
                continue;
            }

            letterIndexMap1[letter1].Add(i);
        }

        const int invalidCycle = -1;

        var nextCycleCache = new Dictionary<(int index, string visitedKey), int>();
        var continueCycleCache = new Dictionary<(int index, int cycleStartIndex, int cycleLength, string visitedKey), int>();

        return FindNextCycle(0);

        int FindNextCycle(int index)
        {
            var key = (index, visitedKey: GetVisitedKey());

            if (nextCycleCache.TryGetValue(key, out var result))
            {
                return result;
            }

            while (index < n && visited.Contains(index))
            {
                index++;
            }

            result = index == n ? 0 : ContinueCycle(index, index, 0);
            nextCycleCache[key] = result;

            return result;
        }

        int ContinueCycle(int index, int cycleStartIndex, int cycleLength)
        {
            var key = (index, cycleStartIndex, cycleLength, visitedKey: GetVisitedKey());

            if (continueCycleCache.TryGetValue(key, out var result))
            {
                return result;
            }

            var letter1 = s1[index];
            var letter2 = s2[index];
            var cycleStartLetter = s1[cycleStartIndex];

            if (letter1 == cycleStartLetter && cycleLength > 0)
            {
                var nextResult = FindNextCycle(cycleStartIndex + 1);
                return nextResult == invalidCycle ? invalidCycle : cycleLength - 1 + nextResult;
            }

            if (!visited.Add(index))
            {
                return invalidCycle;
            }

            result = letterIndexMap1[letter2].Select(nextIndex => ContinueCycle(nextIndex, cycleStartIndex, cycleLength + 1)).Where(nextResult => nextResult != invalidCycle).DefaultIfEmpty(invalidCycle).Min();
            visited.Remove(index);

            continueCycleCache[key] = result;
            return result;
        }

        string GetVisitedKey() => string.Join(",", visited.OrderBy(x => x));
    }
}
