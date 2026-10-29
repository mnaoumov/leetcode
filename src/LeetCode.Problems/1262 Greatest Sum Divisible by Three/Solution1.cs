namespace LeetCode.Problems._1262_Greatest_Sum_Divisible_by_Three;

/// <summary>
/// https://leetcode.com/problems/greatest-sum-divisible-by-three/submissions/1837226054/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSumDivThree(int[] nums)
    {
        var sum = nums.Sum();

        if (sum % 3 == 0)
        {
            return sum;
        }

        var mod1 = nums.Where(num => num % 3 == 1).OrderBy(num => num).ToArray();
        var mod2 = nums.Where(num => num % 3 == 2).OrderBy(num => num).ToArray();
        var diff = int.MaxValue;

        if (sum % 3 == 1)
        {
            if (mod1.Length >= 1)
            {
                diff = Math.Min(diff, mod1[0]);
            }

            if (mod2.Length >= 2)
            {
                diff = Math.Min(diff, mod2[0] + mod2[1]);
            }

            return sum - diff;
        }

        if (mod2.Length >= 1)
        {
            diff = Math.Min(diff, mod2[0]);
        }

        if (mod1.Length >= 2)
        {
            diff = Math.Min(diff, mod1[0] + mod1[1]);
        }

        return sum - diff;
    }
}
