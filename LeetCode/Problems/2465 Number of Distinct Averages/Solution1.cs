namespace LeetCode.Problems._2465_Number_of_Distinct_Averages;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-91/submissions/detail/841986738/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistinctAverages(int[] nums)
    {
        Array.Sort(nums);

        var startIndex = 0;
        var endIndex = nums.Length - 1;
        var averages = new HashSet<double>();

        while (startIndex <= endIndex)
        {
            var average = (nums[startIndex] + nums[endIndex]) / 2.0;
            averages.Add(average);
            startIndex++;
            endIndex--;
        }

        return averages.Count;
    }
}
