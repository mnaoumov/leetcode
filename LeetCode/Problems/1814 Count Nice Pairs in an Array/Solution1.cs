using JetBrains.Annotations;

namespace LeetCode.Problems._1814_Count_Nice_Pairs_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1103133657/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountNicePairs(int[] nums)
    {
        var map = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            var key = num - Rev(num);
            map.TryAdd(key, 0);
            map[key]++;
        }

        return map.Values.Aggregate<int, ModNumber>(0, (current, count) => current + 1L * count * (count - 1) / 2);
    }

    private static int Rev(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            var digit = num % 10;
            ans = ans * 10 + digit;
            num /= 10;
        }

        return ans;
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(long value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }
}
