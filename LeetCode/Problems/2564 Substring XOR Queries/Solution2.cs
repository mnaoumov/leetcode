using JetBrains.Annotations;

namespace LeetCode._2564_Substring_XOR_Queries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-332/submissions/detail/896315924/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int[][] SubstringXorQueries(string s, int[][] queries)
    {
        var n = queries.Length;

        var valueIndicesMap = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var query = queries[i];
            var queryValue = query[0] ^ query[1];

            if (!valueIndicesMap.ContainsKey(queryValue))
            {
                valueIndicesMap[queryValue] = new List<int>();
            }

            valueIndicesMap[queryValue].Add(i);
        }

        var ans = Enumerable.Range(0, n).Select(_ => new[] { -1, -1 }).ToArray();

        for (var left = 0; left < s.Length; left++)
        {
            if (s[left] == '0')
            {
                if (valueIndicesMap.TryGetValue(0, out var indices))
                {
                    foreach (var index in indices)
                    {
                        ans[index] = new[] { left, left };
                    }

                    valueIndicesMap.Remove(0);
                }

                continue;
            }

            var value = 0;

            for (var right = left; right < s.Length; right++)
            {
                var digit = s[right] - '0';
                value = value << 1 | digit;

                if (!valueIndicesMap.TryGetValue(value, out var value1))
                {
                    continue;
                }

                foreach (var index in value1)
                {
                    ans[index] = new[] { left, right };
                }

                valueIndicesMap.Remove(value);
            }
        }

        return ans;
    }
}
