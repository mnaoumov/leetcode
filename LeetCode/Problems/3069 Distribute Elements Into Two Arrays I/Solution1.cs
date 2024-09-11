namespace LeetCode.Problems._3069_Distribute_Elements_Into_Two_Arrays_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-387/submissions/detail/1192150311/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ResultArray(int[] nums)
    {
        var arr1 = new List<int> { nums[0] };
        var arr2 = new List<int> { nums[1] };

        for (var i = 2; i < nums.Length; i++)
        {
            if (arr1[^1] > arr2[^1])
            {
                arr1.Add(nums[i]);
            }
            else
            {
                arr2.Add(nums[i]);
            }
        }

        return arr1.Concat(arr2).ToArray();
    }
}
