using JetBrains.Annotations;

namespace LeetCode.Problems._1658_Minimum_Operations_to_Reduce_X_to_Zero;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums, int x)
    {
        var leftCapacityIndexMap = new Dictionary<int, int>
        {
            [x] = -1
        };

        var leftCapacity = x;

        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            leftCapacity -= nums[i];

            if (leftCapacity < 0)
            {
                break;
            }

            leftCapacityIndexMap[leftCapacity] = i;
        }

        var ans = int.MaxValue;

        var rightCapacity = x;

        for (var i = 0; i < n; i++)
        {
            var rightIndex = n - i;

            if (leftCapacityIndexMap.TryGetValue(x - rightCapacity, out var leftIndex) && leftIndex < rightIndex)
            {
                ans = Math.Min(ans, leftIndex + i + 1);
            }

            rightCapacity -= nums[rightIndex - 1];

            if (rightCapacity < 0)
            {
                break;
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}
