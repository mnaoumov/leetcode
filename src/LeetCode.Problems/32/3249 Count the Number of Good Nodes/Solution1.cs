namespace LeetCode.Problems._3249_Count_the_Number_of_Good_Nodes;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-410/submissions/detail/1351530004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountGoodNodes(int[][] edges)
    {
        var n = edges.Length + 1;
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        return Dfs(0, -1).goodCount;

        (int goodCount, int size) Dfs(int node, int parent)
        {
            var goodCount = 0;
            var size = 1;
            var sampleSize = 0;
            var isGoodNode = true;

            foreach (var child in adjNodes[node].Except(new[] { parent }))
            {
                var (childGoodCount, childSize) = Dfs(child, node);
                goodCount += childGoodCount;
                size += childSize;

                if (sampleSize == 0)
                {
                    sampleSize = childSize;
                }

                if (childSize != sampleSize)
                {
                    isGoodNode = false;
                }
            }

            if (isGoodNode)
            {
                goodCount++;
            }

            return (goodCount, size);
        }
    }
}
