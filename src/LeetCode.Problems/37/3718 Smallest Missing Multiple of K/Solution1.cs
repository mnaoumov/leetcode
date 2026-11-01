namespace LeetCode.Problems._3718_Smallest_Missing_Multiple_of_K;

/// <seealso href="https://leetcode.com/contest/weekly-contest-472/problems/smallest-missing-multiple-of-k/submissions/1805454729/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MissingMultiple(int[] nums, int k)
    {
        var set = nums.ToHashSet();
        var num = 0;

        while (true)
        {
            num += k;

            if (!set.Contains(num))
            {
                return num;
            }
        }
    }
}
