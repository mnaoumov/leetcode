namespace LeetCode.Problems._3244_Shortest_Distance_After_Road_Addition_Queries_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1343757072/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        var m = queries.Length;
        var ans = new int[m];

        var cities = Enumerable.Range(0, n).ToList();

        for (var i = 0; i < m; i++)
        {
            var query = queries[i];
            var u = query[0];
            var v = query[1];

            var uIndex = cities.BinarySearch(u);
            var vIndex = cities.BinarySearch(v);

            if (uIndex >= 0 && vIndex >= 0)
            {
                cities.RemoveRange(uIndex + 1, vIndex - uIndex - 1);
            }

            ans[i] = cities.Count - 1;
        }

        return ans;
    }
}
