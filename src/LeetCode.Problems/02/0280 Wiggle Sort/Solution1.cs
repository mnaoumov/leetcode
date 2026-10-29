namespace LeetCode.Problems._0280_Wiggle_Sort;

/// <summary>
/// https://leetcode.com/submissions/detail/893747494/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void WiggleSort(int[] nums)
    {
        var result = new List<int>();

        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            var num1 = nums[i];
            var num2 = i < n - 1 ? nums[i + 1] : 0;

            if (i < n - 1)
            {
                if (num1 > num2)
                {
                    (num1, num2) = (num2, num1);
                }
            }

            var num1InsertPosition = result.Count == 0 || result[^1] >= num1 ? result.Count : result.Count - 1;
            result.Insert(num1InsertPosition, num1);

            if (i == n - 1)
            {
                break;
            }

            result.Add(num2);
            i++;
        }

        for (var i = 0; i < n; i++)
        {
            nums[i] = result[i];
        }
    }
}
