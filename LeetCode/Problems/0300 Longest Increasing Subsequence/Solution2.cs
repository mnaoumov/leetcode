namespace LeetCode.Problems._0300_Longest_Increasing_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/919779060/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LengthOfLIS(int[] nums)
    {
        var sequence = new List<int>();
        var result = 0;

        foreach (var num in nums)
        {
            if (sequence.Count == 0 || sequence[^1] < num)
            {
                sequence.Add(num);
                result = sequence.Count;
            }
            else
            {
                var low = 0;
                var high = sequence.Count - 1;

                while (low <= high)
                {
                    var mid = low + (high - low >> 1);

                    if (num <= sequence[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                sequence[low] = num;
            }
        }

        return result;
    }
}
