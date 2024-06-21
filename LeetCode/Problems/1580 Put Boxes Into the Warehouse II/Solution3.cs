using JetBrains.Annotations;

namespace LeetCode.Problems._1580_Put_Boxes_Into_the_Warehouse_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1289486372/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
    {
        var n = warehouse.Length;
        Array.Sort(boxes);
        return GetCount(0, 0, 0);

        int GetCount(int boxIndex, int leftBarrierIndex, int rightBarrierIndex)
        {
            if (boxIndex == 0)
            {
                var ans = 0;
                var maxIndex = 0;

                for (var i = 0; i < n; i++)
                {
                    if (warehouse[i] < boxes[0])
                    {
                        break;
                    }

                    ans = Math.Max(ans, 1 + GetCount(1, i, i));
                    maxIndex = 0;
                }

                for (var i = n - 1; i > maxIndex; i--)
                {
                    if (warehouse[i] < boxes[0])
                    {
                        break;
                    }

                    ans = Math.Max(ans, 1 + GetCount(1, i, i));
                }

                return ans;
            }

            if (boxIndex == boxes.Length)
            {
                return 0;
            }

            if (leftBarrierIndex < 0)
            {
                return 0;
            }

            if (rightBarrierIndex >= n)
            {
                return 0;
            }

            var box = boxes[boxIndex];
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

            if (maxPushingFromTheLeftIndex < 0 && minPushingFromTheRightIndex >= n)
            {
                return 0;
            }

            return 1 + Math.Max(
                GetCount(boxIndex + 1, maxPushingFromTheLeftIndex, rightBarrierIndex),
                GetCount(boxIndex + 1, leftBarrierIndex, minPushingFromTheRightIndex)
            );
        }
    }
}
