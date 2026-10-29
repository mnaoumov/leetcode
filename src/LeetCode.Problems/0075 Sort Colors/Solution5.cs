namespace LeetCode.Problems._0075_Sort_Colors;

/// <summary>
/// https://leetcode.com/submissions/detail/829032127/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public void SortColors(int[] nums)
    {
        var count0 = 0;
        var count1 = 0;

        foreach (var num in nums)
        {
            switch (num)
            {
                case 0:
                    count0++;
                    break;
                case 1:
                    count1++;
                    break;
            }
        }

        for (var i = 0; i < count0; i++)
        {
            nums[i] = 0;
        }

        for (var i = count0; i < count0 + count1; i++)
        {
            nums[i] = 1;
        }

        for (var i = count0 + count1; i < nums.Length; i++)
        {
            nums[i] = 2;
        }
    }
}
