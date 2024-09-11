namespace LeetCode.Problems._2562_Find_the_Array_Concatenation_Value;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-332/submissions/detail/896248929/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long FindTheArrayConcVal(int[] nums)
    {
        var result = 0L;
        var n = nums.Length;

        for (var i = 0; i <= (n - 1) / 2; i++)
        {
            var num1 = nums[i];

            if (i == n - 1 - i)
            {
                result += num1;
            }
            else
            {
                var num2 = nums[n - 1 - i];
                var powerOfTen = 1L;

                while (powerOfTen <= num2)
                {
                    powerOfTen *= 10;
                }

                result += num1 * powerOfTen + num2;
            }
        }

        return result;
    }
}
