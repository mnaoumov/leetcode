using JetBrains.Annotations;

namespace LeetCode._0427_Construct_Quad_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905633717/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public Node Construct(int[][] grid)
    {
        var n = grid.Length;
        return Build((0, n), (0, n));

        Node Build((int from, int to) rowRange, (int from, int to) columnRange)
        {
            if (IsSingle(rowRange) && IsSingle(columnRange))
            {
                return BuildLeafNode(rowRange, columnRange);
            }

            var rowMid = Middle(rowRange);
            var columnMid = Middle(columnRange);

            var topRowRange = (rowRange.from, rowMid);
            var bottomRowRange = (rowMid, rowRange.to);
            var leftColumnRange = (columnRange.from, columnMid);
            var rightColumnRange = (columnMid, columnRange.to);

            var node = new Node
            {
                topLeft = Build(topRowRange, leftColumnRange),
                topRight = Build(topRowRange, rightColumnRange),
                bottomLeft = Build(bottomRowRange, leftColumnRange),
                bottomRight = Build(bottomRowRange, rightColumnRange)
            };

            var subNodes = new[] { node.topLeft, node.topRight, node.bottomLeft, node.bottomRight };

            return subNodes.All(subNode => subNode.isLeaf && subNode.val == node.topLeft.val) ? BuildLeafNode(rowRange, columnRange) : node;
        }

        Node BuildLeafNode((int from, int to) rowRange, (int from, int to) columnRange) => new(grid[rowRange.from][columnRange.from] == 1, true);

        int Middle((int from, int to) range) => (range.from + range.to) / 2;
        bool IsSingle((int from, int to) range) => range.to - range.from == 1;
    }
}
