namespace LeetCode.Problems._3354_Make_Array_Elements_Equal_to_Zero;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-424/submissions/detail/1454819616/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountValidSelections(int[] nums)
    {
        var ans = 0;
        var directions = new[] { 1, -1 };

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num != 0)
            {
                continue;
            }

            ans += directions.Count(direction => Test(i, direction));
        }

        return ans;

        bool Test(int index, int direction)
        {
            var copy = nums.ToArray();
            var nonZerosCount = nums.Count(num => num > 0);

            while (0 <= index && index < nums.Length)
            {
                var num = copy[index];

                if (num > 0)
                {
                    copy[index]--;
                    if (copy[index] == 0)
                    {
                        nonZerosCount--;
                    }
                    direction = -direction;
                }

                index += direction;
            }

            return nonZerosCount == 0;
        }
    }
}
