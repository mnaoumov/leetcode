namespace LeetCode.Problems._1522_Diameter_of_N_Ary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/950546115/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Diameter(Node root)
    {
        var heights = new Dictionary<Node, int>();
        return Diameter2(root);

        int Diameter2(Node node)
        {
            var ans = Height(node);

            if (node.children == null)
            {
                return ans;
            }

            var childHeights = new List<int>();

            foreach (var child in node.children)
            {
                ans = Math.Max(ans, Diameter2(child));
                childHeights.Add(Height(child));
            }

            childHeights = childHeights.OrderByDescending(h => h).ToList();

            if (childHeights.Count > 1)
            {
                ans = Math.Max(ans, 2 + childHeights[0] + childHeights[1]);
            }

            return ans;
        }

        int Height(Node node)
        {
            if (heights.TryGetValue(node, out var height))
            {
                return height;
            }

            height = (node.children ?? new List<Node>()).Select(child => 1 + Height(child)).Prepend(0).Max();
            heights[node] = height;
            return height;
        }
    }
}
