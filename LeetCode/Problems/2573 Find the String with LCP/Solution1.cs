using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2573_Find_the_String_with_LCP;

/// <summary>
/// https://leetcode.com/submissions/detail/901659041/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string FindTheString(int[][] lcp)
    {
        var n = lcp.Length;

        var parents = Enumerable.Range(0, n).ToArray();
        var differentLetterIndicesMap = new Dictionary<int, HashSet<int>>();

        for (var i = 0; i < n; i++)
        {
            if (lcp[i][i] != n - i)
            {
                return "";
            }

            for (var j = i + 1; j < n; j++)
            {
                if (lcp[i][j] != lcp[j][i])
                {
                    return "";
                }

                if (lcp[i][j] > n - j)
                {
                    return "";
                }

                int k;

                for (k = 0; k <= Math.Min(lcp[i][j], n - 1 - j); k++)
                {
                    var root1 = GetRoot(i + k);
                    var root2 = GetRoot(j + k);

                    if (k < lcp[i][j])
                    {
                        if (root1 == root2)
                        {
                            continue;
                        }

                        if (differentLetterIndicesMap.GetValueOrDefault(root1, new HashSet<int>()).Any(differentLetterIndex => GetRoot(differentLetterIndex) == root2))
                        {
                            return "";
                        }

                        parents[root2] = root1;
                    }
                    else
                    {
                        if (root1 == root2)
                        {
                            return "";
                        }

                        if (!differentLetterIndicesMap.ContainsKey(root1))
                        {
                            differentLetterIndicesMap[root1] = new HashSet<int>();
                        }

                        differentLetterIndicesMap[root1].Add(root2);
                    }
                }
            }
        }

        var sb = new StringBuilder();
        var letter = 'a';

        var rootLetterMap = new Dictionary<int, char>();

        for (var i = 0; i < n; i++)
        {
            var root = GetRoot(i);

            if (!rootLetterMap.ContainsKey(root))
            {
                if (letter > 'z')
                {
                    return "";
                }

                rootLetterMap[root] = letter;
                letter++;
            }

            sb.Append(rootLetterMap[root]);
        }

        return sb.ToString();

        int GetRoot(int index)
        {
            if (parents[index] == index)
            {
                return index;
            }

            var root = GetRoot(parents[index]);
            parents[index] = root;

            if (!differentLetterIndicesMap.ContainsKey(index))
            {
                return root;
            }

            if (!differentLetterIndicesMap.ContainsKey(root))
            {
                differentLetterIndicesMap[root] = new HashSet<int>();
            }

            differentLetterIndicesMap[root].UnionWith(differentLetterIndicesMap[index]);
            differentLetterIndicesMap.Remove(index);

            return root;
        }
    }
}
