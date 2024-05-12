using JetBrains.Annotations;

namespace LeetCode._2476_Closest_Nodes_Queries_in_a_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-320/submissions/detail/846634153/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
    {
        return queries.Select(query => new[] { FindMin(query), FindMax(query) }).ToArray<IList<int>>();

        int FindMin(int query)
        {
            var node = root;

            var result = -1;

            while (node != null)
            {
                if (node.val == query)
                {
                    return query;
                }

                if (node.val > query)
                {
                    node = node.left;
                }
                else
                {
                    result = node.val;
                    node = node.right;
                }
            }

            return result;
        }

        int FindMax(int query)
        {
            var node = root;

            var result = -1;

            while (node != null)
            {
                if (node.val == query)
                {
                    return query;
                }

                if (node.val < query)
                {
                    node = node.right;
                }
                else
                {
                    result = node.val;
                    node = node.left;
                }
            }

            return result;
        }
    }
}
