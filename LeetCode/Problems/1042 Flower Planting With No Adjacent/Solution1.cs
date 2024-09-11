namespace LeetCode.Problems._1042_Flower_Planting_With_No_Adjacent;

/// <summary>
/// https://leetcode.com/submissions/detail/925768722/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GardenNoAdj(int n, int[][] paths)
    {
        var adjacentGardens = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();

        foreach (var path in paths)
        {
            adjacentGardens[path[0]].Add(path[1]);
            adjacentGardens[path[1]].Add(path[0]);
        }

        var result = new int[n];

        for (var garden = 1; garden <= n; garden++)
        {
            Dfs(garden);
        }

        return result;

        void Dfs(int garden)
        {
            if (result[garden - 1] != 0)
            {
                return;
            }

            var candidates = Enumerable.Range(1, 4).ToHashSet();

            foreach (var adjacentGarden in adjacentGardens[garden])
            {
                candidates.Remove(result[adjacentGarden - 1]);
            }

            result[garden - 1] = candidates.First();

            foreach (var adjacentGarden in adjacentGardens[garden])
            {
                Dfs(adjacentGarden);
            }
        }
    }
}
