using JetBrains.Annotations;

namespace LeetCode.Problems._0737_Sentence_Similarity_II;

/// <summary>
/// https://leetcode.com/submissions/detail/933405447/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
    {
        if (sentence1.Length != sentence2.Length)
        {
            return false;
        }

        var uf = new UnionFind<string>();

        foreach (var list in similarPairs)
        {
            uf.Union(list[0], list[1]);
        }

        return sentence1.Zip(sentence2, (word1, word2) => (word1, word2))
            .All(x => uf.Connected(x.word1, x.word2));
    }

    private class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        private T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

        public void Union(T x, T y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX.Equals(rootY))
            {
                return;
            }

            var rankX = GetRank(rootX);
            var rankY = GetRank(rootY);

            if (rankX < rankY)
            {
                _roots[rootX] = rootY;
            }
            else if (rankX > rankY)
            {
                _roots[rootY] = rootX;
            }
            else
            {
                _roots[rootX] = rootY;
                _ranks[rootY] = GetRank(rootY) + 1;
            }
        }

        private int GetRank(T x) => _ranks.GetValueOrDefault(x, 1);

        public bool Connected(T x, T y) => Find(x).Equals(Find(y));
    }
}
