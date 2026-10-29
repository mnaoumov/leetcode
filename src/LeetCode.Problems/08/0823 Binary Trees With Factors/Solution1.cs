namespace LeetCode.Problems._0823_Binary_Trees_With_Factors;

/// <summary>
/// https://leetcode.com/submissions/detail/1084241556/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumFactoredBinaryTrees(int[] arr)
    {
        Array.Sort(arr);
        var set = arr.ToHashSet();

        var treeCounts = new Dictionary<int, ModNumber>();

        var n = arr.Length;

        ModNumber ans = 0;

        for (var i = 0; i < n; i++)
        {
            var num = arr[i];
            treeCounts[num] = 1;

            for (var j = 0; j < i; j++)
            {
                var left = arr[j];

                if (num % left != 0)
                {
                    continue;
                }

                var right = num / left;

                if (!set.Contains(right))
                {
                    continue;
                }

                treeCounts[num] += treeCounts[left] * treeCounts[right];
            }

            ans += treeCounts[num];
        }

        return ans;
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
}
