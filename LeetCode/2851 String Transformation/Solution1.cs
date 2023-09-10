using JetBrains.Annotations;

namespace LeetCode._2851_String_Transformation;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfWays(string s, string t, long k)
    {
        var n = s.Length;
        var desiredIndices = new List<int>();

        ModNumber sampleHash = 0;
        var lettersCount = LetterToIndex('z') + 1;

        for (var i = 0; i < n; i++)
        {
            sampleHash *= lettersCount;
            sampleHash += LetterToIndex(s[i]);
        }

        ModNumber topPower = 1;

        for (var i = 0; i < n - 1; i++)
        {
            topPower *= lettersCount;
        }

        var hash = sampleHash;

        for (var i = 0; i < n; i++)
        {
            if (hash == sampleHash)
            {
                desiredIndices.Add(i);
            }

            var num = LetterToIndex(s[i]);
            hash -= topPower * num;
            hash *= lettersCount;
            hash += num;
        }

        if (k == 1)
        {
            return desiredIndices.Count - 1;
        }



        ModNumber ans = 0;
        return ans;
    }

    private static int LetterToIndex(char letter) => letter - 'a';

    private class ModNumber : IEquatable<ModNumber>
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

        public bool Equals(ModNumber? other) => other is not null && _value == other._value;

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is ModNumber number && Equals(number);
        }

        public override int GetHashCode() => _value;

        public static bool operator ==(ModNumber? left, ModNumber? right) => Equals(left, right);

        public static bool operator !=(ModNumber? left, ModNumber? right) => !Equals(left, right);
    }
}
