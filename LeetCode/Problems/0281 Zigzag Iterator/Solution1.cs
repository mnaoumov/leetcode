namespace LeetCode.Problems._0281_Zigzag_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/947555261/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IZigzagIterator Create(IList<int> v1, IList<int> v2) => new ZigzagIterator(v1, v2);

    private class ZigzagIterator : IZigzagIterator
    {
        private readonly IEnumerator<int> _enumerator;

        public ZigzagIterator(IList<int> v1, IList<int> v2) => _enumerator = Enumerate(v1, v2).GetEnumerator();

        private static IEnumerable<int> Enumerate(IList<int> v1, IList<int> v2)
        {
            var i = 0;

            while (i < v1.Count && i < v2.Count)
            {
                yield return v1[i];
                yield return v2[i];
                i++;
            }

            while (i < v1.Count)
            {
                yield return v1[i];
                i++;
            }

            while (i < v2.Count)
            {
                yield return v2[i];
                i++;
            }
        }

        public bool HasNext() => _enumerator.MoveNext();
        public int Next() => _enumerator.Current;
    }
}
