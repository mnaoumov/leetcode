using JetBrains.Annotations;

namespace LeetCode._1428_Leftmost_Column_with_at_Least_a_One;

/// <summary>
/// https://leetcode.com/submissions/detail/1140930444/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
    {
        var dimensions = binaryMatrix.Dimensions();
        var rows = dimensions[0];
        var cols = dimensions[1];

        var min = 0;
        var max = cols - 1;

        while (min <= max)
        {
            var mid = min + (max - min >> 1);

            if (HasOne(mid))
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }

        return min < cols ? min : -1;

        bool HasOne(int column) => Enumerable.Range(0, rows).Any(row => binaryMatrix.Get(row, column) == 1);
    }
}
