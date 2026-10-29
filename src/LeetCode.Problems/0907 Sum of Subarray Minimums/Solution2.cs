namespace LeetCode.Problems._0907_Sum_of_Subarray_Minimums;

/// <summary>
/// https://leetcode.com/submissions/detail/849838197/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SumSubarrayMins(int[] arr)
    {
        var cache = new Cache();

        foreach (var num in arr)
        {
            cache.Add(num);
        }

        return cache.Result;
    }

    private class Cache
    {
        private const int Modulo = 1000000007;

        public int Result { get; private set; }

        private int NodesCount { get; set; }
        private int ValuesCount { get; set; }

        private readonly List<CacheNode> _nodes = new();
        private static readonly IComparer<CacheNode> Comparer = GenericPropertyComparer<CacheNode>.Create(x => x.Minimum);

        public void Add(int num)
        {
            ValuesCount++;
            var indexToInsert = _nodes.BinarySearch(
                index: 0,
                count: NodesCount,
                new CacheNode
                {
                    Minimum = num
                },
                comparer: Comparer
            );

            if (indexToInsert < 0)
            {
                indexToInsert = ~indexToInsert;

                if (indexToInsert == NodesCount)
                {
                    _nodes.Add(new CacheNode());
                }
            }

            var previousTotal = indexToInsert > 0 ? _nodes[indexToInsert - 1].RunningTotal : 0;
            var currentNode = _nodes[indexToInsert];
            currentNode.Minimum = num;
            var previousLastValueIndex = indexToInsert > 0 ? _nodes[indexToInsert - 1].LastValueIndex : -1;
            currentNode.LastValueIndex = ValuesCount - 1;
            currentNode.RunningTotal = (previousTotal + num * (currentNode.LastValueIndex - previousLastValueIndex)) % Modulo;
            NodesCount = indexToInsert + 1;
            Result = (Result + currentNode.RunningTotal) % Modulo;
        }

        private class CacheNode
        {
            public int Minimum { get; set; }
            public int LastValueIndex { get; set; }
            public int RunningTotal { get; set; }
        }
    }

    private abstract class GenericPropertyComparer<T> : IComparer<T>
    {
        public abstract int Compare(T? x, T? y);

        public static GenericPropertyComparer<T> Create<TProperty>(Func<T, TProperty> propertyFunc) where TProperty : IComparable<TProperty> => new GenericPropertyComparer<T, TProperty>(propertyFunc);
    }

    private class GenericPropertyComparer<T, TProperty> : GenericPropertyComparer<T> where TProperty : IComparable<TProperty>
    {
        private readonly Func<T, TProperty> _propertyFunc;

        public GenericPropertyComparer(Func<T, TProperty> propertyFunc) => _propertyFunc = propertyFunc;

        public override int Compare(T? x, T? y)
        {
            var isXNull = x == null;
            var isYNull = y == null;

            return isXNull ? isYNull ? 0 : -1 : isYNull ? 1 : _propertyFunc(x!).CompareTo(_propertyFunc(y!));
        }
    }
}
