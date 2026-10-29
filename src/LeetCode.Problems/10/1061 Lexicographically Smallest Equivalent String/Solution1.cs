namespace LeetCode.Problems._1061_Lexicographically_Smallest_Equivalent_String;

/// <summary>
/// https://leetcode.com/submissions/detail/878281641/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var n = s1.Length;

        var uf = new UnionFind<char>();

        for (var i = 0; i < n; i++)
        {
            uf.Union(s1[i], s2[i]);
        }

        return string.Join("", baseStr.Select(letter => uf.Find(letter)));
    }

    private class UnionFind<T> where T : IComparable<T>
    {
        private readonly Dictionary<T, T> _parentMap = new();

        public void Union(T item1, T item2)
        {
            var min1 = Find(item1);
            var min2 = Find(item2);

            switch (min1.CompareTo(min2))
            {
                case 0:
                    return;
                case < 0:
                    _parentMap[min2] = min1;
                    break;
                case > 0:
                    _parentMap[min1] = min2;
                    break;
            }
        }

        public T Find(T item)
        {
            _parentMap.TryAdd(item, item);

            if (!_parentMap[item].Equals(item))
            {
                _parentMap[item] = Find(_parentMap[item]);
            }

            return _parentMap[item];
        }
    }
}
