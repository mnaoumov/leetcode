namespace LeetCode.Problems._3876_Construct_Uniform_Parity_Array_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-494/problems/construct-uniform-parity-array-ii/submissions/1955261564/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool UniformArray(int[] nums1)
    {
        var evens = new SortedSet<int>(nums1.Where(num => num % 2 == 0));
        var odds = new SortedSet<int>(nums1.Where(num => num % 2 == 1));

        if (evens.Count == 0 || odds.Count == 0)
        {
            return true;
        }

        return evens.Min > odds.Min;
    }
}
