using JetBrains.Annotations;

namespace LeetCode.Problems._1580_Put_Boxes_Into_the_Warehouse_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1290709831/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MaxBoxesInWarehouse(int[] boxes, int[] warehouse)
    {
        var effectHeights = new int[warehouse.Length];
        var minHeight = int.MaxValue;

        for (var i = 0; i < warehouse.Length; i++)
        {
            minHeight = Math.Min(minHeight, warehouse[i]);
            effectHeights[i] = minHeight;
        }

        minHeight = int.MaxValue;

        for (var i = warehouse.Length - 1; i >= 0; i--)
        {
            minHeight = Math.Min(minHeight, warehouse[i]);
            effectHeights[i] = Math.Max(effectHeights[i], minHeight);
        }

        Array.Sort(boxes);
        Array.Sort(effectHeights);

        var ans = 0;
        var warehouseIndex = 0;

        foreach (var box in boxes)
        {
            while (warehouseIndex < warehouse.Length && box > effectHeights[warehouseIndex])
            {
                warehouseIndex++;
            }

            if (warehouseIndex == warehouse.Length)
            {
                break;
            }

            ans++;
            warehouseIndex++;
        }

        return ans;
    }
}
