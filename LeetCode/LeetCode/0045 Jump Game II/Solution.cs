namespace LeetCode._0045_Jump_Game_II;

/// <summary>
/// https://leetcode.com/submissions/detail/815079985/
/// </summary>
public class Solution : ISolution
{
    public int Jump(int[] nums)
    {
        var cache = new int?[nums.Length];

        return GetCached(0);

        int GetCached(int index)
        {
            if (cache[index] is not { } cachedResult)
            {
                cache[index] = cachedResult = Calculate();
            }

            return cachedResult;

            int Calculate()
            {
                if (index == nums.Length - 1)
                {
                    return 0;
                }

                var result = int.MaxValue;

                for (var j = 1; j <= nums[index] && index + j < nums.Length; j++)
                {
                    var subResult = GetCached(index + j);
                    if (subResult < int.MaxValue)
                    {
                        result = Math.Min(result, subResult + 1);
                    }
                }

                return result;
            }
        }
    }
}