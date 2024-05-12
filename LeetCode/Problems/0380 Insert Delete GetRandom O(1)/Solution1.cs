using JetBrains.Annotations;

namespace LeetCode.Problems._0380_Insert_Delete_GetRandom_O_1_;

/// <summary>
/// https://leetcode.com/submissions/detail/851798782/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IRandomizedSet Create() => new RandomizedSet();

    private class RandomizedSet : IRandomizedSet
    {
        private readonly HashSet<int> _set = new();
        private readonly List<int> _list = new();
        private readonly Random _random = new();

        public bool Insert(int val)
        {
            var result = _set.Add(val);

            if (result)
            {
                _list.Add(val);
            }

            return result;
        }

        public bool Remove(int val)
        {
            var result = _set.Remove(val);

            if (result)
            {
                _list.Remove(val);
            }

            return result;
        }

        public int GetRandom()
        {
            var randomIndex = _random.Next(_list.Count);
            return _list[randomIndex];
        }
    }
}
