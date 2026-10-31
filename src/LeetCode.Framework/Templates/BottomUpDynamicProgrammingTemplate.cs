// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedVariable
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051

namespace LeetCode.Templates;

public static class BottomUpDynamicProgrammingTemplate
{
    private static int Sample()
    {
        const int n = 10;
        const int m = 10;

        var dp = new BottomUpDynamicProgramming<(int a, int b), int>(
            from a in Enumerable.Range(0, n)
            from b in Enumerable.Range(0, m)
            select (a, b),
            (key, get) =>
            {
                var (a, b) = key;
                return 0;
            });

        return dp.Get((n - 1, m - 1));
    }

    // Bottom-up: orderedKeys must list every state after the states its calculation reads; no recursion, so no stack depth limit.
    public sealed class BottomUpDynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _values = new();

        public BottomUpDynamicProgramming(IEnumerable<TKey> orderedKeys, Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            foreach (var key in orderedKeys)
            {
                _values[key] = func(key, Get);
            }
        }

        public TValue Get(TKey key) => _values.TryGetValue(key, out var value)
            ? value
            : throw new InvalidOperationException($"State {key} is read before it is calculated");
    }
}
