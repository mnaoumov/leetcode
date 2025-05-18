namespace LeetCode.Problems._3551_Minimum_Swaps_to_Sort_by_Digit_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-450/problems/minimum-swaps-to-sort-by-digit-sum/submissions/1636875088/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSwaps(int[] nums)
    {
        var sorted = nums
            .OrderBy(DigitSum)
            .ThenBy(num => num)
            .ToArray();

        var sortedNumIndexMap = new Dictionary<int, int>();

        var n = nums.Length;
        for (var i = 0; i < n; i++)
        {
            sortedNumIndexMap[sorted[i]] = i;
        }

        var permutation = new int[n];
        for (var i = 0; i < n; i++)
        {
            permutation[i] = sortedNumIndexMap[nums[i]];
        }

        var processedIndices = new HashSet<int>();
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            if (processedIndices.Contains(i))
            {
                continue;
            }

            var index = i;
            var cycleSize = 0;

            while (cycleSize == 0 || index != i)
            {
                index = permutation[index];
                cycleSize++;
                processedIndices.Add(index);
            }

            ans += cycleSize - 1;
        }

        return ans;
    }

    private static int DigitSum(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            ans += num % 10;
            num /= 10;
        }

        return ans;
    }
}
