using JetBrains.Annotations;

namespace LeetCode._0045_Jump_Game_II;

/// <summary>
/// https://leetcode.com/submissions/detail/829022922/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int Jump(int[] nums)
    {
        var cache = new int?[nums.Length];

        return GetCached(0);

        int GetCached(int index)
        {
            if (cache[index] is not { } result)
            {
                cache[index] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (index == nums.Length - 1)
                {
                    return 0;
                }

                var result2 = int.MaxValue;

                for (var j = 1; j <= nums[index] && index + j < nums.Length; j++)
                {
                    var subResult = GetCached(index + j);
                    if (subResult < int.MaxValue)
                    {
                        result2 = Math.Min(result2, subResult + 1);
                    }
                }

                return result2;
            }
        }
    }
}
