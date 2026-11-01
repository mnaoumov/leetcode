namespace LeetCode.Problems._2433_Find_The_Original_Array_of_Prefix_Xor;

/// <seealso href="https://leetcode.com/submissions/detail/891020987/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindArray(int[] pref) =>
        pref.Select((value, index) => value ^ (index == 0 ? 0 : pref[index - 1])).ToArray();
}
