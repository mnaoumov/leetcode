namespace LeetCode.Problems._0961_N_Repeated_Element_in_Size_2N_Array;

/// <summary>
/// https://leetcode.com/problems/n-repeated-element-in-size-2n-array/submissions/1871477558/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RepeatedNTimes(int[] nums)
    {
        var seen = new HashSet<int>();

        foreach (var num in nums)
        {
            if (!seen.Add(num))
            {
                return num;
            }
        }

        throw new ArgumentException("Invalid input.");
    }
}
