using JetBrains.Annotations;

namespace LeetCode.Problems._1647_Minimum_Deletions_to_Make_Character_Frequencies_Unique;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDeletions(string s)
    {
        var frequenciesMap = s.GroupBy(letter => letter).GroupBy(g => g.Count())
            .ToDictionary(g => g.Key, g => g.Count());

        var frequenciesPq = new PriorityQueue<int, int>();

        foreach (var frequency in frequenciesMap.Keys)
        {
            frequenciesPq.Enqueue(frequency, -frequency);
        }

        var ans = 0;

        while (frequenciesPq.Count > 0)
        {
            var maxFrequency = frequenciesPq.Dequeue();
            var count = frequenciesMap[maxFrequency];

            if (count <= 1)
            {
                continue;
            }

            ans += count - 1;

            if (maxFrequency == 1)
            {
                break;
            }

            if (!frequenciesMap.ContainsKey(maxFrequency - 1))
            {
                frequenciesMap.Add(maxFrequency - 1, 0);
                frequenciesPq.Enqueue(maxFrequency - 1, 1 - maxFrequency);
            }

            frequenciesMap[maxFrequency - 1] += count - 1;
        }

        return ans;
    }
}
