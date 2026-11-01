namespace LeetCode.Problems._0070_Climbing_Stairs;

/// <seealso href="https://leetcode.com/submissions/detail/820362789/">Submission</seealso>
/// <seealso href="https://leetcode.com/submissions/detail/858357437/">Submission</seealso>
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
