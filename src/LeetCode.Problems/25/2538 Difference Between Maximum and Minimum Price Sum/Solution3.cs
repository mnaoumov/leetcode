namespace LeetCode.Problems._2538_Difference_Between_Maximum_and_Minimum_Price_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/878410422/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MaxOutput(int n, int[][] edges, int[] price)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var result = 0L;

        Dfs(0, -1);

        return result;

        (long maxSumForFullPath, long maxSumForPathWithoutLeaf) Dfs(int node, int parent)
        {
            var maxSumForFullPath = 0L;
            var maxSumForPathWithoutLeaf = 0L;
            var nodePrice = price[node];

            var isChildrenProcessStarted = false;

            foreach (var child in neighbors[node].Except(new[] { parent }))
            {
                var (childMaxSumForFullPath, childMaxSumForPathWithoutLeaf) = Dfs(child, node);

                result = Math.Max(result,
                    childMaxSumForFullPath + (!isChildrenProcessStarted ? 0 : nodePrice + maxSumForPathWithoutLeaf));
                result = Math.Max(result, childMaxSumForPathWithoutLeaf + nodePrice + maxSumForFullPath);
                maxSumForFullPath = Math.Max(maxSumForFullPath, childMaxSumForFullPath);
                maxSumForPathWithoutLeaf = Math.Max(maxSumForPathWithoutLeaf, childMaxSumForPathWithoutLeaf);
                isChildrenProcessStarted = true;
            }

            maxSumForFullPath += nodePrice;

            if (isChildrenProcessStarted)
            {
                maxSumForPathWithoutLeaf += nodePrice;
            }

            return (maxSumForFullPath, maxSumForPathWithoutLeaf);
        }
    }
}
