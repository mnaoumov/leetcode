using JetBrains.Annotations;

namespace LeetCode._0055_Jump_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/819419839/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CanJump(int[] nums)
    {
        var cache = new bool?[nums.Length];

        return GetCachedOrCalculate(0);

        bool GetCachedOrCalculate(int index)
        {
            if (cache[index] is not { } result)
            {
                cache[index] = result = Calculate();
            }

            return result;

            bool Calculate()
            {
                if (index == nums.Length - 1)
                {
                    return true;
                }

                var maxJump = Math.Min(nums[index], nums.Length - 1 - index);

                for (var i = 1; i <= maxJump; i++)
                {
                    if (GetCachedOrCalculate(index + i))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
