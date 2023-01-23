using JetBrains.Annotations;

namespace LeetCode._0997_Find_the_Town_Judge;

/// <summary>
/// https://leetcode.com/submissions/detail/883361177/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindJudge(int n, int[][] trust)
    {
        var trustsMap = new Dictionary<int, HashSet<int>>();

        foreach (var arr in trust)
        {
            if (!trustsMap.ContainsKey(arr[0]))
            {
                trustsMap[arr[0]] = new HashSet<int>();
            }

            trustsMap[arr[0]].Add(arr[1]);
        }

        const int impossible = -1;

        if (trustsMap.Keys.Count != n - 1)
        {
            return impossible;
        }

        var judge = Enumerable.Range(1, n).Except(trustsMap.Keys).First();

        return trustsMap.Values.All(trustedPeople => trustedPeople.Contains(judge)) ? judge : impossible;
    }
}
