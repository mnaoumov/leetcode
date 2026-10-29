namespace LeetCode.Problems._1233_Remove_Sub_Folders_from_the_Filesystem;

/// <summary>
/// https://leetcode.com/submissions/detail/1432940846/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        var root = new TrieNode("");

        foreach (var path in folder)
        {
            var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var node = root;

            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];

                if (!node.Children.TryGetValue(part, out var child))
                {
                    node.Children[part] = child = new TrieNode(part);
                }

                node = child;
                if (i == parts.Length - 1)
                {
                    node.IsEnd = true;
                }
            }
        }

        var ans = new List<string>();
        Fill(root, "");
        return ans;

        void Fill(TrieNode node, string prefix)
        {
            var nextPrefix = node.Value == "" ? "" : prefix + "/" + node.Value;
            if (node.IsEnd)
            {
                ans.Add(nextPrefix);
                return;
            }

            foreach (var child in node.Children.Values)
            {
                Fill(child, nextPrefix);
            }
        }
    }

    private class TrieNode
    {
        public string Value { get; }
        public bool IsEnd;
        public readonly Dictionary<string, TrieNode> Children = new();

        public TrieNode(string value)
        {
            Value = value;
        }
    }
}
