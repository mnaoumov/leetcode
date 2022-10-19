using JetBrains.Annotations;

namespace LeetCode._2440_Create_Components_With_Same_Value;

/// <summary>
/// </summary>
[UsedImplicitly]
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

                for (var node = 0; node < statuses.Length; node++)
                {
                    if (statuses[node] == NodeStatus.Visited)
                    {
                        continue;
                    }

                    statuses[node] = NodeStatus.Unvisited;
                    if (nextNode == NotFound)
                    {
                        nextNode = node;
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
                    nextLevelNodes.AddRange(GetAvailableNeighbors(node));
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