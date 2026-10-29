namespace LeetCode.Problems._1359_Count_All_Valid_Pickup_and_Delivery_Options;

/// <summary>
/// https://leetcode.com/submissions/detail/1045144379/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountOrders(int n) => Enumerable.Range(1, n).Aggregate((ModNumber) 1, (cur, i) => cur * i * (2 * i - 1));

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
}
