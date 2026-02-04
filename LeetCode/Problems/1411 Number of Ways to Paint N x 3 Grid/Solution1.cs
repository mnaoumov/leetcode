using System.Numerics;

namespace LeetCode.Problems._1411_Number_of_Ways_to_Paint_N_x_3_Grid;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-paint-n-3-grid/submissions/1872618664/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumOfWays(int n)
    {
        var triplets = new List<ColorTriplet>();
        var colors = Enum.GetValues<Color>();

        foreach (var color1 in colors)
        {
            foreach (var color2 in colors)
            {
                foreach (var color3 in colors)
                {
                    var triplet = new ColorTriplet(color1, color2, color3);

                    if (triplet.IsValid)
                    {
                        triplets.Add(triplet);
                    }
                }
            }
        }

        var neighborsMap = new Dictionary<ColorTriplet, List<ColorTriplet>>();

        foreach (var triplet1 in triplets)
        {
            foreach (var triplet2 in triplets.Where(triplet2 => triplet1.IsValidNeighbor(triplet2)))
            {
                neighborsMap.TryAdd(triplet1, new List<ColorTriplet>());
                neighborsMap[triplet1].Add(triplet2);
            }
        }

        var counts = new Dictionary<ColorTriplet, ModNumber>();
        foreach (var triplet in triplets)
        {
            counts[triplet] = 1;
        }

        for (var rowIndex = 1; rowIndex < n; rowIndex++)
        {
            var newCounts = new Dictionary<ColorTriplet, ModNumber>();
            foreach (var triplet in triplets)
            {
                var counts2 = counts;
                newCounts[triplet] = ModNumber.Sum(neighborsMap[triplet].Select(neighbor => counts2[neighbor]));
            }
            counts = newCounts;
        }

        return ModNumber.Sum(counts.Values);
    }

    private enum Color
    {
        // ReSharper disable once UnusedMember.Local
        Red,
        // ReSharper disable once UnusedMember.Local
        Yellow,
        // ReSharper disable once UnusedMember.Local
        Green
    }

    private record ColorTriplet(Color Color1, Color Color2, Color Color3)
    {
        public bool IsValid => Color1 != Color2 && Color2 != Color3;

        public bool IsValidNeighbor(ColorTriplet triplet2)
        {
            return Color1 != triplet2.Color1 && Color2 != triplet2.Color2 && Color3 != triplet2.Color3;
        }
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
