namespace LeetCode.Problems._2200_Find_All_K_Distant_Indices_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/find-all-k-distant-indices-in-an-array/submissions/1674288248/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        var ans = new List<int>();
        var minNext = 0;
        var j = 0;
        while (j < nums.Length)
        {
            if (nums[j] != key)
            {
                j++;
                continue;
            }

            for (var i = Math.Max(minNext, j - k); i <= Math.Min(nums.Length - 1, j + k); i++)
            {
                ans.Add(i);
            }

            minNext = j + k + 1;
            j++;
        }

        return ans;
    }
}
