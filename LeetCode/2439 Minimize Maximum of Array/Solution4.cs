using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._2439_Minimize_Maximum_of_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-89/submissions/detail/823071916/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MinimizeArrayValue(int[] nums)
    {
        var longNums = nums.Select(num => (long) num).ToArray();
        var runningSum = longNums.Sum();

        for (var i = longNums.Length - 1; i >= 1; i--)
        {
            var minPossibleResult = Math.Max(longNums[0], (int) Math.Ceiling((double) runningSum / (i + 1)));

            if (longNums[i] > minPossibleResult)
            {
                longNums[i - 1] += longNums[i] - minPossibleResult;
                longNums[i] = minPossibleResult;
            }

            runningSum -= longNums[i];
        }

        return (int) longNums.Max();
    }
}
