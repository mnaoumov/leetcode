using JetBrains.Annotations;

namespace LeetCode._1258_Synonymous_Sentences;

/// <summary>
/// https://leetcode.com/submissions/detail/934389388/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
    {
        var uf = new UnionFind<string>();

        foreach (var synonym in synonyms)
        {
            uf.Union(synonym[0], synonym[1]);
        }

        var setsMap = new Dictionary<string, SortedSet<string>>();

        foreach (var synonym in synonyms)
        {
            var key = uf.Find(synonym[0]);
            setsMap.TryAdd(key, new SortedSet<string>());
            setsMap[key].Add(synonym[0]);
            setsMap[key].Add(synonym[1]);
        }

        var words = text.Split(' ');
        var result = new List<string>();
        var resultWords = new List<string>();
        Backtrack(0);

        return result;

        void Backtrack(int index)
        {
            if (index == words.Length)
            {
                result.Add(string.Join(' ', resultWords));
                return;
            }

            var word = words[index];
            var key = uf.Find(word);

            var equivalentWords = setsMap.GetValueOrDefault(key, new SortedSet<string> { word });

            foreach (var equivalentWord in equivalentWords)
            {
                resultWords.Add(equivalentWord);
                Backtrack(index + 1);
                resultWords.RemoveAt(resultWords.Count - 1);
            }
        }
    }

    private class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        public T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

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
    }
}
