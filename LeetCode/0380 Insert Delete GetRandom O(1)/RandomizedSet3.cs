namespace LeetCode._0380_Insert_Delete_GetRandom_O_1_;

/// <summary>
/// https://leetcode.com/submissions/detail/851805806/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class RandomizedSet3 : IRandomizedSet
{
    private readonly List<int> _list = new();
    private readonly Random _random = new();
    private readonly Dictionary<int, int> _valueIndexMap = new();

    public bool Insert(int val)
    {

        if (_valueIndexMap.ContainsKey(val))
        {
            return false;
        }

        _list.Add(val);

        _valueIndexMap[val] = _list.Count - 1;

        return true;
    }

    public bool Remove(int val)
    {
        if (!_valueIndexMap.ContainsKey(val))
        {
            return false;
        }

        var index = _valueIndexMap[val];

        (_list[index], _list[^1]) = (_list[^1], _list[index]);

        _list.RemoveAt(_list.Count - 1);
        _valueIndexMap.Remove(val);
        _valueIndexMap[_list[index]] = index;
        return true;
    }

    public int GetRandom()
    {
        var randomIndex = _random.Next(_list.Count);
        return _list[randomIndex];
    }
}
