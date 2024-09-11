using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable
#pragma warning disable CS8321
#pragma warning disable CS8602

namespace LeetCode.Problems._2440_Create_Components_With_Same_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/826255453/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
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

            return TryBuildNextComponent();

            bool TryBuildNextComponent()
            {
                var nextNode = NotFound;

                foreach (var levelNode in nodesByLevelsList.SelectMany(levelNodes => levelNodes.Where(levelNode => statuses[levelNode] != NodeStatus.Visited)))
                {
                    statuses[levelNode] = NodeStatus.Unvisited;
                    if (nextNode == NotFound)
                    {
                        nextNode = levelNode;
                    }
                }

                if (nextNode != NotFound)
                {
                    if (!TryBuildComponent(new[] { nextNode }, fullComponentSum))
                    {
                        return false;
                    }
                }

                return true;
            }

            bool TryBuildComponent(int[] nodes, int componentSumAvailable)
            {
                var nextLevelNodes = new List<int>();
                var currentComponentSumAvailable = componentSumAvailable;

                foreach (var node in nodes)
                {
                    statuses[node] = NodeStatus.Visited;
                    currentComponentSumAvailable -= nums[node];
                    nextLevelNodes.AddRange(nextLevelNeighborLists[node]);
                }

                if (currentComponentSumAvailable == 0)
                {
                    if (TryBuildNextComponent())
                    {
                        return true;
                    }
                }
                else
                {
                    var nextLevelNodesLists = GetNextLevelNodesLists(0, currentComponentSumAvailable).ToArray();

                    foreach (var nextLevelNodesList in nextLevelNodesLists)
                    {
                        var skippedNodes = nextLevelNodes.Except(nextLevelNodesList).ToArray();

                        foreach (var skippedNode in skippedNodes)
                        {
                            statuses[skippedNode] = NodeStatus.Skipped;
                        }

                        if (TryBuildComponent(nextLevelNodesList, currentComponentSumAvailable))
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

                IEnumerable<int[]> GetNextLevelNodesLists(int nextLevelNodeIndex, int sumAvailable)
                {
                    if (sumAvailable == 0)
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

                            foreach (var list in GetNextLevelNodesLists(nextLevelNodeIndex + 1, sumAvailable - nextLevelNodeValue))
                            {
                                yield return singleNodeList.Concat(list).ToArray();
                            }
                        }

                        nextLevelNodeIndex++;
                    }
                }
            }

            IEnumerable<int> GetAvailableNeighbors(int node)
            {
                foreach (var edge in edges)
                {
                    var neighbor = NotFound;

                    if (edge[0] == node)
                    {
                        neighbor = edge[1];
                    }
                    else if (edge[1] == node)
                    {
                        neighbor = edge[0];
                    }

                    if (neighbor != NotFound && statuses[neighbor] == NodeStatus.Unvisited)
                    {
                        yield return neighbor;
                    }
                }
            }
        }
    }

    private enum NodeStatus
    {
        Unvisited,
        Visited,
        Skipped
    }
}
