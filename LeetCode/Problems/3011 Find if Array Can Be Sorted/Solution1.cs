namespace LeetCode.Problems._3011_Find_if_Array_Can_Be_Sorted;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-122/submissions/detail/1151645880/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanSortArray(int[] nums)
    {
        var sorted = nums.OrderBy(x => x).ToArray();

        var i = 0;
        var iBitsCount = CountBits(nums[i]);

        while (i < nums.Length)
        {
            var j = i + 1;
            var jBitsCount = 0;

            while (j < nums.Length)
            {
                jBitsCount = CountBits(nums[j]);

                if (jBitsCount != iBitsCount)
                {
                    break;
                }

                j++;
            }

            var part = nums.Skip(i).Take(j - i).OrderBy(x => x);

            if (!part.SequenceEqual(sorted.Skip(i).Take(j - i)))
            {
                return false;
            }

            i = j;
            iBitsCount = jBitsCount;
        }

        return true;
    }

    private static int CountBits(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            ans += num & 1;
            num >>= 1;
        }

        return ans;
    }
}
