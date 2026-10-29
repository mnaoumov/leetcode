namespace LeetCode.Problems._0167_Two_Sum_II___Input_Array_Is_Sorted;

/// <summary>
/// https://leetcode.com/submissions/detail/875910433/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var i = 1;
        var j = numbers.Length;

        while (true)
        {
            var sum = numbers[i - 1] + numbers[j - 1];

            if (sum == target)
            {
                return new[] { i, j };
            }

            if (sum < target)
            {
                i++;
            }
            else
            {
                j--;
            }
        }
    }
}
