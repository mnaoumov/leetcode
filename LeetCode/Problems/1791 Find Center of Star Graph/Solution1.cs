using JetBrains.Annotations;

namespace LeetCode.Problems._1791_Find_Center_of_Star_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/1301411659/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindCenter(int[][] edges)
    {
        var nodes = new HashSet<int>();

        foreach (var edge in edges)
        {
            foreach (var node in edge)
            {
                if (!nodes.Add(node))
                {
                    return node;
                }
            }
        }

        throw new InvalidOperationException();
    }
}
