using JetBrains.Annotations;

namespace LeetCode._3139_Minimum_Cost_to_Equalize_Array;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinCostToEqualizeArray(int[] nums, int cost1, int cost2)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return 0;
        }

        var max = nums.Max();
        var diffs = nums.Select(num => max - num).OrderBy(x => x).ToList();

        ModNumber pairCounts = 0;

        while (diffs[^2] > 0)
        {
            pairCounts += diffs[^2];
            var modifiedLast = diffs[^1] - diffs[^2];
            diffs.RemoveRange(diffs.Count - 2, 2);
            InsertInOrderedList(diffs, 0);
            InsertInOrderedList(diffs, modifiedLast);
        }

        cost2 = Math.Min(cost2, 2 * cost1);

        if ((n - 1) * cost2 < (n - 2) * cost1)
        {
            while (diffs[^1] > n - 1)
            {
                pairCounts += n - 1;
                diffs[^1] -= n - 2;
            }
        }

        return pairCounts * cost2 + (ModNumber) diffs[^1] * cost1;
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }

    private static void InsertInOrderedList<T>(List<T> list, T item)
    {
        var index = list.BinarySearch(item);

        if (index < 0)
        {
            index = ~index;
        }

        list.Insert(index, item);
    }
}
