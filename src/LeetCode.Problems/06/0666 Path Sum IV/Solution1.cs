namespace LeetCode.Problems._0666_Path_Sum_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/1372682048/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PathSum(int[] nums)
    {
        nums = nums.OrderByDescending(num => num).ToArray();

        var previousDepth = int.MaxValue;
        var ans = 0;
        var previousDepthPositions = new Dictionary<int, int>();
        var currentDepthPositions = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            var depth = num / 100;
            var position = num / 10 % 10;
            var value = num % 10;

            if (depth != previousDepth)
            {
                previousDepthPositions = currentDepthPositions;
                currentDepthPositions = new Dictionary<int, int>();
                previousDepth = depth;
            }

            var count = previousDepthPositions.GetValueOrDefault(2 * position - 1)
                        + previousDepthPositions.GetValueOrDefault(2 * position);

            if (count == 0)
            {
                count = 1;
            }

            currentDepthPositions.Add(position, count);
            ans += count * value;
        }

        return ans;
    }
}
