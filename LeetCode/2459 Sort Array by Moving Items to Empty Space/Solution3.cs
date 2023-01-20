using JetBrains.Annotations;

namespace LeetCode._2459_Sort_Array_by_Moving_Items_to_Empty_Space;

/// <summary>
/// https://leetcode.com/submissions/detail/879052694/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int SortArray(int[] nums)
    {
        var n = nums.Length;

        var count1 = GetSwapCount(isZeroFromTheLeftSide: true);
        var count2 = GetSwapCount(isZeroFromTheLeftSide: false);

        return Math.Min(count1, count2);

        int GetSwapCount(bool isZeroFromTheLeftSide)
        {
            var result = 0;
            var zeroIndex = isZeroFromTheLeftSide ? 0 : n - 1;

            var set = new HashSet<int>();


            for (var num = 0; num < n; num++)
            {
                if (set.Contains(num))
                {
                    continue;
                }

                var next = num;
                var cycleLength = 0;
                var hasZero = false;

                do
                {
                    set.Add(next);

                    if (next == zeroIndex)
                    {
                        hasZero = true;
                    }

                    cycleLength++;

                    if (isZeroFromTheLeftSide)
                    {
                        next = nums[next];
                    }
                    else
                    {
                        next = nums[next] - 1;

                        if (next < 0)
                        {
                            next += n;
                        }
                    }
                } while (next != num);

                if (hasZero)
                {
                    result += cycleLength - 1;
                }
                else if (cycleLength != 1)
                {
                    result += cycleLength + 1;
                }
            }

            return result;
        }
    }
}
