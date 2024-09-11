namespace LeetCode.Problems._1695_Maximum_Erasure_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/898975375/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        var counts = new Dictionary<int, int>();
        var n = nums.Length;
        var sum = 0;
        var result = 0;

        var i = 0;

        for (var j = 0; j < n; j++)
        {
            var num = nums[j];
            counts[num] = counts.GetValueOrDefault(num) + 1;
            sum += num;

            if (counts[num] == 1)
            {
                result = Math.Max(result, sum);
            }
            else
            {
                while (true)
                {
                    var previousNum = nums[i];
                    sum -= previousNum;
                    counts[previousNum]--;
                    i++;

                    if (previousNum == num)
                    {
                        break;
                    }
                }
            }
        }

        return result;
    }
}
