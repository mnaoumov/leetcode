using JetBrains.Annotations;

namespace LeetCode._0854_K_Similar_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/886349811/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int KSimilarity(string s1, string s2)
    {
        var possibleLetters = new[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        var letterIndexMap1 = possibleLetters.ToDictionary(letter => letter, _ => new List<int>());
        var letterIndexMap2 = possibleLetters.ToDictionary(letter => letter, _ => new List<int>());

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
            letterIndexMap2[letter2].Add(i);
        }

        var result = int.MaxValue;

        FindNextCycle(0, 0);

        return result;

        void FindNextCycle(int index, int totalSwapsCount)
        {
            if (totalSwapsCount >= result)
            {
                return;
            }

            while (index < n && visited.Contains(index))
            {
                index++;
            }

            if (index == n)
            {
                result = totalSwapsCount;
                return;
            }

            ContinueCycle(index, index, totalSwapsCount, 0);
        }

        void ContinueCycle(int index, int cycleStartIndex, int totalSwapsCount, int cycleLength)
        {
            if (totalSwapsCount >= result)
            {
                return;
            }

            var letter1 = s1[index];
            var letter2 = s2[index];
            var cycleStartLetter = s1[cycleStartIndex];

            if (letter1 == cycleStartLetter && cycleLength > 0)
            {
                FindNextCycle(cycleStartIndex + 1, totalSwapsCount + cycleLength - 1);
            }
            else if (visited.Add(index))
            {
                foreach (var nextIndex in letterIndexMap1[letter2])
                {
                    ContinueCycle(nextIndex, cycleStartIndex, totalSwapsCount, cycleLength + 1);
                }

                visited.Remove(index);
            }
        }
    }
}
