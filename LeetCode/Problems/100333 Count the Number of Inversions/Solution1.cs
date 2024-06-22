using JetBrains.Annotations;

namespace LeetCode.Problems._100333_Count_the_Number_of_Inversions;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfPermutations(int n, int[][] requirements)
    {
        requirements = requirements.OrderByDescending(x => x[0]).ToArray();

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var requirement in requirements)
        {
            var end = requirement[0];
            var cnt = requirement[1];

            if (cnt > end * (end + 1) / 2)
            {
                return 0;
            }
        }

        return Calculate(new SortedSet<int>());

        ModNumber Calculate(SortedSet<int> inverseIndices)
        {
            var minIndex = 0;

            foreach (var requirement in requirements)
            {
                var end = requirement[0];
                var cnt = requirement[1];

                foreach (var inverseIndex in inverseIndices.GetViewBetween(0, end - 1))
                {
                    cnt -= end - inverseIndex;

                    if (cnt < 0)
                    {
                        return 0;
                    }
                }

                if (cnt != 0)
                {
                    if (inverseIndices.Count == n - 1)
                    {
                        return 0;
                    }
                    continue;
                }

                minIndex = end;
                break;
            }

            if (inverseIndices.Count == n - 1)
            {
                return 1;
            }

            ModNumber ans = 0;

            for (var i = minIndex; i < n; i++)
            {
                if (!inverseIndices.Add(i))
                {
                    continue;
                }

                ans += Calculate(inverseIndices);
                inverseIndices.Remove(i);
            }

            return ans;
        }
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
