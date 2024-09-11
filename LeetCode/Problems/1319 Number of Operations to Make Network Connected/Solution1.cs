namespace LeetCode.Problems._1319_Number_of_Operations_to_Make_Network_Connected;

/// <summary>
/// https://leetcode.com/submissions/detail/920491120/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MakeConnected(int n, int[][] connections)
    {
        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var connection in connections)
        {
            adjacentNodes[connection[0]].Add(connection[1]);
            adjacentNodes[connection[1]].Add(connection[0]);
        }

        var seen = new bool[n];
        var extraEdgesCount = 0;
        var componentCount = 0;

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            componentCount++;
            var nodesCount = 0;
            var edgesCount = 0;
            Dfs(i);
            extraEdgesCount += edgesCount / 2 - nodesCount + 1;
            continue;

            void Dfs(int node)
            {
                seen[node] = true;
                nodesCount++;

                foreach (var adjacentNode in adjacentNodes[node])
                {
                    edgesCount++;

                    if (seen[adjacentNode])
                    {
                        continue;
                    }

                    Dfs(adjacentNode);
                }
            }
        }

        return extraEdgesCount >= componentCount - 1 ? componentCount - 1 : -1;
    }
}
