namespace LeetCode._1155_Number_of_Dice_Rolls_With_Target_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/813662085/
/// </summary>
public class Solution : ISolution
{
    private readonly int _modulo = (int)Math.Pow(10, 9) + 7;

    private readonly Dictionary<(int n, int target), int> _cache = new();

    public int NumRollsToTarget(int n, int k, int target)
    {
        var key = (n, target);
        if (!_cache.TryGetValue(key, out var result))
        {
            result = _cache[key] = NumRollsToTargetImpl(n, k, target);
        }

        return result;
    }

    private int NumRollsToTargetImpl(int n, int k, int target)
    {
        if (n == 1)
        {
            if (1 <= target && target <= k)
            {
                return 1;
            }

            return 0;
        }

        if (target < n || n * k < target)
        {
            return 0;
        }

        var result = 0;

        for (var i = 1; i <= k; i++)
        {
            result = (result + NumRollsToTarget(n - 1, k, target - i)) % _modulo;
        }

        return result;
    }
}