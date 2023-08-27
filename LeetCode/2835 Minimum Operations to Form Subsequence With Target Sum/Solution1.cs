using JetBrains.Annotations;

namespace LeetCode._2835_Minimum_Operations_to_Form_Subsequence_With_Target_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-360/submissions/detail/1032781370/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(IList<int> nums, int target)
    {
        const int bitCount = 31;
        var counts = new int[bitCount];

        foreach (var num in nums)
        {
            var power = (int) Math.Log2(num);
            counts[power]++;
        }

        var ans = 0;

        for (var i = 0; i < bitCount; i++)
        {
            var powerOfTwo = 1 << i;

            if ((target & powerOfTwo) != 0)
            {
                var j = i;

                while (counts[j] == 0)
                {
                    j++;

                    if (j == bitCount)
                    {
                        return -1;
                    }
                }

                while (j > i)
                {
                    counts[j]--;
                    counts[j - 1] += 2;
                    j--;
                    ans++;
                }

                counts[i]--;
                target -= powerOfTwo;

                if (target == 0)
                {
                    break;
                }
            }

            counts[i + 1] += counts[i] / 2;
        }

        return ans;
    }
}
