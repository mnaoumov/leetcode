namespace LeetCode.Problems._1128_Number_of_Equivalent_Domino_Pairs;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var counts = new Dictionary<int, int>();

        foreach (var domino in dominoes)
        {
            var min = Math.Min(domino[0], domino[1]);
            var max = Math.Max(domino[0], domino[1]);
            var value = min * 10 + max;
            counts.TryAdd(value, 0);
            counts[value]++;
        }

        return counts.Values.Select(value => value * (value - 1) / 2).Sum();
    }
}
