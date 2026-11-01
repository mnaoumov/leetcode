
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2442_Count_Number_of_Distinct_Integers_After_Reverse_Operations;

/// <seealso href="https://leetcode.com/contest/weekly-contest-315/submissions/detail/823385654/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountDistinctIntegers(int[] nums)
    {
        var set = new HashSet<int>(nums);

        foreach (var num in nums)
        {
            var reversedDigits = num.ToString().Reverse().ToArray();
            var reversedNumber = int.Parse(new string(reversedDigits));
            set.Add(reversedNumber);
        }

        return set.Count;
    }
}
