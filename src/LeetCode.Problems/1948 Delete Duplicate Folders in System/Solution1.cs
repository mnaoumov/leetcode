namespace LeetCode.Problems._1948_Delete_Duplicate_Folders_in_System;

/// <summary>
/// https://leetcode.com/problems/delete-duplicate-folders-in-system/submissions/1704156009/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        var trie = new Trie();

        foreach (var path in paths)
        {
            trie.Insert(path);
        }

        var nodeHashesMap = new Dictionary<TrieNode, int>();
        CalculateHash(trie.Root);

        var nodesGroupedByHash = nodeHashesMap.GroupBy(kvp => kvp.Value, kvp => kvp.Key)
            .Select(g => g.ToArray()).ToArray();

        var duplicateNodes = new HashSet<TrieNode>();

        foreach (var nodes in nodesGroupedByHash)
        {
            for (var i = 0; i < nodes.Length; i++)
            {
                if (duplicateNodes.Contains(nodes[i]))
                {
                    continue;
                }

                for (var j = i + 1; j < nodes.Length; j++)
                {
                    if (nodes[i].ChildNodes.Count <= 0 || nodes[j].ChildNodes.Count <= 0 ||
                        !AreIdentical(nodes[i], nodes[j]))
                    {
                        continue;
                    }

                    duplicateNodes.Add(nodes[i]);
                    duplicateNodes.Add(nodes[j]);
                }
            }
        }

        var ans = new List<IList<string>>();

        FillAnswer(trie.Root, new List<string>());

        return ans;

        int CalculateHash(TrieNode node)
        {
            if (nodeHashesMap.TryGetValue(node, out var hash))
            {
                return hash;
            }

            var hashCode = new HashCode();

            foreach (var (folderName, childNode) in node.ChildNodes.OrderBy(kvp => kvp.Key))
            {
                hashCode.Add(folderName);
                hashCode.Add(CalculateHash(childNode));
            }

            hash = hashCode.ToHashCode();
            nodeHashesMap[node] = hash;
            return hash;
        }

        bool AreIdentical(TrieNode node1, TrieNode node2)
        {
            if (nodeHashesMap[node1] != nodeHashesMap[node2])
            {
                return false;
            }

            var keys1 = node1.ChildNodes.Keys.OrderBy(x => x).ToArray();
            var keys2 = node2.ChildNodes.Keys.OrderBy(x => x).ToArray();

            if (!keys1.SequenceEqual(keys2))
            {
                return false;
            }

            return keys1.All(key => AreIdentical(node1.ChildNodes[key], node2.ChildNodes[key]));
        }

        void FillAnswer(TrieNode node, List<string> currentPath)
        {
            foreach (var (folderName, childNode) in node.ChildNodes)
            {
                if (duplicateNodes.Contains(childNode))
                {
                    continue;
                }

                currentPath.Add(folderName);
                ans.Add(currentPath.ToArray());
                FillAnswer(childNode, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

    private class Trie
    {
        public TrieNode Root { get; } = new();

        public void Insert(IList<string> path)
        {
            var node = Root;

            foreach (var folderName in path)
            {
                if (!node.ChildNodes.TryGetValue(folderName, out var childNode))
                {
                    childNode = new TrieNode();
                    node.ChildNodes.Add(folderName, childNode);
                }

                node = childNode;
            }
        }
    }

    private class TrieNode
    {
        public readonly Dictionary<string, TrieNode> ChildNodes = new();
    }
}
