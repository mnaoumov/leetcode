using JetBrains.Annotations;

namespace LeetCode._2924_Find_Champion_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-370/submissions/detail/1091692421/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindChampion(int n, int[][] edges)
    {
        var candidates = Enumerable.Range(0, n).ToHashSet();

        foreach (var edge in edges)
        {
            candidates.Remove(edge[1]);
        }

        return candidates.Count == 1 ? candidates.First() : -1;
    }
}
