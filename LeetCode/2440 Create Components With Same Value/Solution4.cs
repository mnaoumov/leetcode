using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._2440_Create_Components_With_Same_Value;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    private const int NotFound = -1;

    public int ComponentValue(int[] nums, int[][] edges)
    {
        if (edges.Length == 0)
        {
            return 0;
        }

        var totalSum = nums.Sum();
        var max = nums.Max();

        var neighborLists = new List<int>[nums.Length];

        foreach (var edge in edges)
        {
            AddNeighbor(edge[0], edge[1]);
            AddNeighbor(edge[1], edge[0]);

            void AddNeighbor(int node1, int node2)
            {
                neighborLists[node1] ??= new List<int>();
                neighborLists[node1].Add(node2);
            }
        }

        var nodesByLevelsList = new List<List<int>>
        {
            new() { 0 },
            neighborLists[0]
        };

        while (true)
        {
            var levelNodes = new HashSet<int>();

            foreach (var previousLevelNodeNeighbor in nodesByLevelsList[^1].SelectMany(previousLevelNode => neighborLists[previousLevelNode]))
            {
                levelNodes.Add(previousLevelNodeNeighbor);
            }

            levelNodes.ExceptWith(nodesByLevelsList[^2]);

            if (levelNodes.Count > 0)
            {
                nodesByLevelsList.Add(levelNodes.ToList());
            }
            else
            {
                break;
            }
        }

        var nextLevelNeighborLists = new int[nums.Length][];

        for (var level = 0; level < nodesByLevelsList.Count; level++)
        {
            var levelNodes = nodesByLevelsList[level];

            foreach (var levelNode in levelNodes)
            {
                var neighbors = new HashSet<int>(neighborLists[levelNode]);
                if (level > 0)
                {
                    neighbors.ExceptWith(nodesByLevelsList[level - 1]);
                }

                nextLevelNeighborLists[levelNode] = neighbors.ToArray();
            }
        }

        for (var componentsCount = Math.Min(nums.Length, totalSum / max); componentsCount >= 2; componentsCount--)
        {
            if (CheckIfPartitionPossible(componentsCount))
            {
                return componentsCount - 1;
            }
        }

        return 0;

        bool CheckIfPartitionPossible(int componentsCount)
        {
            if (totalSum % componentsCount != 0)
            {
                return false;
            }

            var fullComponentSum = totalSum / componentsCount;

            var statuses = new NodeStatus[nums.Length];

            return TryBuildNextComponent(0);

            bool TryBuildNextComponent(int componentIndex)
            {
                if (componentIndex == componentsCount)
                {
                    return true;
                }

                var nextNode = NotFound;
                var leftoverMin = max;
                var leftoverMax = 1;
                var availableNodesCount = 0;

                foreach (var levelNode in nodesByLevelsList.SelectMany(levelNodes => levelNodes.Where(levelNode => statuses[levelNode] != NodeStatus.Visited)))
                {
                    statuses[levelNode] = NodeStatus.Unvisited;
                    leftoverMax = Math.Max(leftoverMax, nums[levelNode]);
                    leftoverMin = Math.Min(leftoverMin, nums[levelNode]);
                    availableNodesCount++;

                    if (nextNode == NotFound)
                    {
                        nextNode = levelNode;
                    }
                }

                var nextLeftoverSum = (componentsCount - componentIndex - 1) * fullComponentSum;
                var nextComponentsMinNodeCount = DivideWithRoundUp(nextLeftoverSum, leftoverMax);
                var componentMaxNodeCount = Math.Min(DivideWithRoundUp(fullComponentSum, leftoverMin), availableNodesCount - nextComponentsMinNodeCount);

                return TryBuildComponent(new[] { nextNode }, fullComponentSum, componentIndex, componentMaxNodeCount);
            }

            bool TryBuildComponent(int[] nodes, int componentSumAvailable, int componentIndex, int componentMaxNodeCount)
            {
                var nextLevelNodes = new List<int>();
                var currentComponentSumAvailable = componentSumAvailable;

                foreach (var node in nodes)
                {
                    statuses[node] = NodeStatus.Visited;
                    currentComponentSumAvailable -= nums[node];
                    componentMaxNodeCount--;
                    nextLevelNodes.AddRange(nextLevelNeighborLists[node]);
                }

                if (currentComponentSumAvailable == 0)
                {
                    if (TryBuildNextComponent(componentIndex + 1))
                    {
                        return true;
                    }
                }
                else
                {
                    if (componentMaxNodeCount == 0)
                    {
                        return false;
                    }

                    var nextLevelNodesLists =
                        GetNextLevelNodesLists(0, currentComponentSumAvailable, componentMaxNodeCount).ToArray();

                    foreach (var nextLevelNodesList in nextLevelNodesLists)
                    {
                        var skippedNodes = nextLevelNodes.Except(nextLevelNodesList).ToArray();

                        foreach (var skippedNode in skippedNodes)
                        {
                            statuses[skippedNode] = NodeStatus.Skipped;
                        }

                        if (TryBuildComponent(nextLevelNodesList, currentComponentSumAvailable, componentIndex, componentMaxNodeCount))
                        {
                            return true;
                        }

                        foreach (var skippedNode in skippedNodes)
                        {
                            statuses[skippedNode] = NodeStatus.Unvisited;
                        }
                    }
                }

                foreach (var node in nodes)
                {
                    statuses[node] = NodeStatus.Unvisited;
                    componentSumAvailable += nums[node];
                }

                return false;

                IEnumerable<int[]> GetNextLevelNodesLists(int nextLevelNodeIndex, int sumAvailable, int availableNodesCount)
                {
                    if (sumAvailable == 0 || availableNodesCount == 0)
                    {
                        yield break;
                    }

                    while (true)
                    {
                        if (nextLevelNodeIndex >= nextLevelNodes.Count)
                        {
                            yield break;
                        }

                        var nextLevelNode = nextLevelNodes[nextLevelNodeIndex];
                        var nextLevelNodeValue = nums[nextLevelNode];
                        if (nextLevelNodeValue <= sumAvailable)
                        {
                            var singleNodeList = new[] { nextLevelNode };
                            yield return singleNodeList;

                            foreach (var list in GetNextLevelNodesLists(nextLevelNodeIndex + 1, sumAvailable - nextLevelNodeValue, availableNodesCount - 1))
                            {
                                yield return singleNodeList.Concat(list).ToArray();
                            }
                        }

                        nextLevelNodeIndex++;
                    }
                }
            }
        }
    }

    private static int DivideWithRoundUp(int a, int b)
    {
        return (int) Math.Ceiling((double) a / b);
    }

    private enum NodeStatus
    {
        Unvisited,
        Visited,
        Skipped
    }
}
