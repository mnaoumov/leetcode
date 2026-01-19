namespace LeetCode.Problems._0756_Pyramid_Transition_Matrix;

/// <summary>
/// https://leetcode.com/problems/pyramid-transition-matrix/submissions/1868901712/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        var allowedLetterMap = new Dictionary<(char left, char right), List<char>>();

        foreach (var triplet in allowed)
        {
            var key = (triplet[0], triplet[1]);
            allowedLetterMap.TryAdd(key, new List<char>());
            allowedLetterMap[key].Add(triplet[2]);
        }

        var candidates = new HashSet<string> { bottom };

        while (candidates.Count > 0 && candidates.First().Length > 1)
        {
            var nextCandidates = new HashSet<string>();

            foreach (var candidate in candidates)
            {
                var prefixes = new List<string> { "" };
                var isValidCandidate = true;

                for (var i = 0; i < candidate.Length - 1; i++)
                {
                    var key = (candidate[i], candidate[i + 1]);
                    var nextLetters = allowedLetterMap.GetValueOrDefault(key, new List<char>());

                    if (nextLetters.Count == 0)
                    {
                        isValidCandidate = false;
                        break;
                    }

                    var nextPrefixes = new List<string>();

                    foreach (var prefix in prefixes.ToArray())
                    {
                        nextPrefixes.AddRange(nextLetters.Select(nextLetter => prefix + nextLetter));
                    }

                    prefixes = nextPrefixes;
                }

                if (!isValidCandidate)
                {
                    continue;
                }

                foreach (var prefix in prefixes)
                {
                    nextCandidates.Add(prefix);
                }
            }

            candidates = nextCandidates;
        }

        return candidates.Count > 0;
    }
}
