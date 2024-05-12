using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1202_Smallest_String_With_Swaps;

/// <summary>
/// https://leetcode.com/submissions/detail/931570745/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
    {
        var n = s.Length;
        var uf = new UnionFind(n);

        foreach (var pair in pairs)
        {
            uf.Union(pair[0], pair[1]);
        }

        var componentsMap = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var componentId = uf.Find(i);
            componentsMap.TryAdd(componentId, new List<int>());
            componentsMap[componentId].Add(i);
        }

        var sb = new StringBuilder(s);

        foreach (var (_, indices) in componentsMap)
        {
            var sortedLetters = indices.Select(i => s[i]).OrderBy(letter => letter).ToArray();

            foreach (var (index, sortedLetter) in indices.Zip(sortedLetters))
            {
                sb[index] = sortedLetter;
            }
        }

        return sb.ToString();
    }

    private class UnionFind
    {
        private readonly int[] _roots;
        private readonly int[] _ranks;

        public UnionFind(int size)
        {
            _roots = Enumerable.Range(0, size).ToArray();
            _ranks = Enumerable.Repeat(1, size).ToArray();
        }

        public int Find(int x) => x == _roots[x] ? x : _roots[x] = Find(_roots[x]);

        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            var rankX = _ranks[rootX];
            var rankY = _roots[rootY];

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
                _ranks[rootY]++;
            }
        }
    }
}
