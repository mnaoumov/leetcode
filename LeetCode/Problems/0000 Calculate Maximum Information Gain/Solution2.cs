using JetBrains.Annotations;

namespace LeetCode.Problems._0000_Calculate_Maximum_Information_Gain;

/// <summary>
/// https://leetcode.com/submissions/detail/922141320/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public double CalculateMaxInfoGain(double[] petal_length, string[] species)
    {
        if (species.Length == 0)
        {
            return 0d;
        }

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once InlineTemporaryVariable
        var L = species;

        var orderedSpecies = species.Select((item, index) => (item, index)).OrderBy(x => petal_length[x.index])
            .Select(x => x.item).ToArray();

        var result = double.NegativeInfinity;

        for (var i = 0; i < species.Length; i++)
        {
            // ReSharper disable once InconsistentNaming
            var L1 = orderedSpecies.Take(i).ToArray();

            // ReSharper disable once InconsistentNaming
            var L2 = orderedSpecies.Skip(i).ToArray();

            result = Math.Max(result, InformationGain(L, L1, L2));
        }

        return result;
    }

    // ReSharper disable InconsistentNaming
    private static double InformationGain(IReadOnlyCollection<string> L, IReadOnlyCollection<string> L1,
        IReadOnlyCollection<string> L2) => H(L) - H(L1) * L1.Count / L.Count - H(L2) * L2.Count / L.Count;
    // ReSharper restore InconsistentNaming

    private static double H<T>(IReadOnlyCollection<T> input)
    {
        var probabilities = input.GroupBy(num => num).Select(g => 1d * g.Count() / input.Count);
        var result = -probabilities.Sum(p => p * Math.Log2(p));
        return result == 0d ? 0d : result;
    }
}
