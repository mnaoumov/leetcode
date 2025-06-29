namespace LeetCode.Problems._2014_Longest_Subsequence_Repeated_k_Times;

/// <summary>
/// https://leetcode.com/problems/longest-subsequence-repeated-k-times/submissions/1680517164/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        var n = s.Length;
        var maxSubsequenceLength = n / k;

        var letterCounts = s
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count() / k)
            .Where(kvp => kvp.Value > 0)
            .ToDictionary();

        var candidates = new List<string>();
        GenerateCandidates("");
        candidates = candidates.OrderByDescending(x => x.Length).ThenByDescending(x => x).ToList();

        return candidates.First(IsValid);

        void GenerateCandidates(string prefix)
        {
            candidates.Add(prefix);

            if (prefix.Length == maxSubsequenceLength)
            {
                return;
            }

            foreach (var (letter, count) in letterCounts)
            {
                if (count == 0)
                {
                    continue;
                }

                letterCounts[letter]--;
                GenerateCandidates(prefix + letter);
                letterCounts[letter]++;
            }
        }

        bool IsValid(string candidate)
        {
            if (candidate == "")
            {
                return true;
            }

            var countsLeft = k;
            var candidateIndex = 0;

            for (var i = 0; i < n; i++)
            {
                if (n - i + candidateIndex < candidate.Length * countsLeft)
                {
                    return false;
                }

                if (s[i] != candidate[candidateIndex])
                {
                    continue;
                }

                candidateIndex++;

                if (candidateIndex != candidate.Length)
                {
                    continue;
                }

                countsLeft--;
                candidateIndex = 0;

                if (countsLeft == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
