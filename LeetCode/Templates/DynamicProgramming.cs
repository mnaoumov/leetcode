namespace LeetCode.Templates;

public class DynamicProgramming<TKey, TValue> where TKey : notnull
{
    private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
    private readonly Dictionary<TKey, TValue> _cache = new();

    public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
    {
        _func = func;
    }

    public TValue GetOrCalculate(TKey key)
    {
        if (!_cache.TryGetValue(key, out var value))
        {
            _cache[key] = value = _func(key, GetOrCalculate);
        }

        return value;
    }
}
