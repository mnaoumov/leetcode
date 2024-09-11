using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1580_Put_Boxes_Into_the_Warehouse_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1289265754/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
    {
        Array.Sort(boxes);

        var n = warehouse.Length;
        var ans = 0;

        for (var firstBoxIndex = 0; firstBoxIndex < n; firstBoxIndex++)
        {
            if (warehouse[firstBoxIndex] < boxes[0])
            {
                continue;
            }

            var boxCount = 1;

            var leftBarrierIndex = firstBoxIndex;
            var rightBarrierIndex = firstBoxIndex;

            foreach (var box in boxes.Skip(1))
            {
                var maxPushingFromTheLeftIndex = leftBarrierIndex - 1;
                for (var i = 0; i < leftBarrierIndex; i++)
                {
                    if (warehouse[i] >= box)
                    {
                        continue;
                    }

                    maxPushingFromTheLeftIndex = i - 1;
                    break;
                }

                var minPushingFromTheRightIndex = rightBarrierIndex + 1;
                for (var i = n - 1; i > rightBarrierIndex; i--)
                {
                    if (warehouse[i] >= box)
                    {
                        continue;
                    }

                    minPushingFromTheRightIndex = i + 1;
                    break;
                }

                const int impossibleHeight = int.MaxValue;
                var heightLeft = maxPushingFromTheLeftIndex < 0 ? impossibleHeight : warehouse[maxPushingFromTheLeftIndex];
                var heightRight = minPushingFromTheRightIndex >= n ? impossibleHeight : warehouse[minPushingFromTheRightIndex];

                if (heightLeft == impossibleHeight && heightRight == impossibleHeight)
                {
                    break;
                }

                if (heightRight < heightLeft)
                {
                    rightBarrierIndex = minPushingFromTheRightIndex;
                }
                else
                {
                    leftBarrierIndex = maxPushingFromTheLeftIndex;
                }

                boxCount++;
            }

            ans = Math.Max(ans, boxCount);
        }

        return ans;
    }
}
