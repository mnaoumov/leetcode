namespace LeetCode.Problems._1086_High_Five;

/// <summary>
/// https://leetcode.com/problems/high-five/submissions/2134599135/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] HighFive(int[][] items)
    {
        return items
            .Select(arr => (id: arr[0], score: arr[1]))
            .GroupBy(x => x.id)
            .OrderBy(g => g.Key)
            .Select(g => new[]
                {
                    g.Key,
                    (int) g
                        .Select(x => x.score)
                        .OrderByDescending(score => score)
                        .Take(5)
                        .Average()
                }
            )
            .ToArray();
    }
}
