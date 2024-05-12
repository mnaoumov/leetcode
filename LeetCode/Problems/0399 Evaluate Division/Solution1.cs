using JetBrains.Annotations;

namespace LeetCode.Problems._0399_Evaluate_Division;

/// <summary>
/// https://leetcode.com/submissions/detail/904882839/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var ratios = new Dictionary<string, Dictionary<string, double>>();

        for (var i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            var a = equation[0];
            var b = equation[1];
            var ratio = values[i];
            AddRatio(a, b, ratio);
            AddRatio(b, a, 1.0 / ratio);
        }

        return queries.Select(query => GetRatio(query[0], query[1])).ToArray();

        void AddRatio(string a, string b, double ratio)
        {
            if (!ratios.ContainsKey(a))
            {
                ratios[a] = new Dictionary<string, double>();
            }

            ratios[a][b] = ratio;
        }

        double GetRatio(string a, string b)
        {
            const double unknown = -1.0;

            if (!ratios.ContainsKey(a) || !ratios.ContainsKey(b))
            {
                return unknown;
            }

            var seen = new HashSet<string>();
            var queue = new Queue<(string denominator, double ratio)>();
            queue.Enqueue((a, 1.0));

            while (queue.Count > 0)
            {
                var (denominator, ratio) = queue.Dequeue();

                if (denominator == b)
                {
                    return ratio;
                }

                if (!seen.Add(denominator))
                {
                    continue;
                }

                foreach (var (nextDenominator, nextRatio) in ratios[denominator])
                {
                    queue.Enqueue((nextDenominator, ratio * nextRatio));
                }
            }

            return unknown;
        }
    }
}
