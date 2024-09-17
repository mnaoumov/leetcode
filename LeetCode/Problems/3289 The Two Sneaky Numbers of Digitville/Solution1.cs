namespace LeetCode.Problems._3289_The_Two_Sneaky_Numbers_of_Digitville;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-415/submissions/detail/1390480658/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        var set = new HashSet<int>();
        return nums.Where(num => !set.Add(num)).ToArray();
    }
}
