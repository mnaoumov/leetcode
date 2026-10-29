namespace LeetCode.Problems._0128_Longest_Consecutive_Sequence;

/// <summary>
/// https://leetcode.com/problems/longest-consecutive-sequence/submissions/836539948/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int LongestConsecutive(int[] nums)
    {
        var processedNums = new HashSet<int>();
        var leftToRightMap = new Dictionary<int, int>();
        var rightToLeftMap = new Dictionary<int, int>();
        var result = 0;

        foreach (var num in nums)
        {
            if (!processedNums.Add(num))
            {
                continue;
            }

            var left = num;
            var right = num;

            if (leftToRightMap.ContainsKey(num + 1))
            {
                right = leftToRightMap[num + 1];
            }

            if (rightToLeftMap.ContainsKey(num - 1))
            {
                left = rightToLeftMap[num - 1];
            }

            leftToRightMap[left] = right;
            rightToLeftMap[right] = left;
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
