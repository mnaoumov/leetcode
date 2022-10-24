using JetBrains.Annotations;

namespace LeetCode._0070_Climbing_Stairs;

/// <summary>
/// https://leetcode.com/submissions/detail/820362789/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ClimbStairs(int n)
    {
        var cache = new int?[n + 1];
        return Get(n);

        int Get(int i)
        {
            if (cache[i] is not { } result)
            {
                cache[i] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                return i switch
                {
                    0 => 1,
                    1 => 1,
                    _ => Get(i - 1) + Get(i - 2)
                };
            }
        }
    }
}