namespace LeetCode.Problems._2349_Design_a_Number_Container_System;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INumberContainers Create() => new NumberContainers();

    private class NumberContainers : INumberContainers
    {
        private readonly Dictionary<int, int> _indexToNumberMap = new();
        private readonly Dictionary<int, SortedSet<int>> _numberToIndicesMap = new();

        public void Change(int index, int number)
        {
            if (_indexToNumberMap.TryGetValue(index, out var oldNumber))
            {
                _numberToIndicesMap[oldNumber].Remove(index);

                if (_numberToIndicesMap[oldNumber].Count == 0)
                {
                    _numberToIndicesMap.Remove(oldNumber);
                }
            }
            _indexToNumberMap[index] = number;
            _numberToIndicesMap.TryAdd(number, new SortedSet<int>());
            _numberToIndicesMap[number].Add(index);
        }
    
        public int Find(int number)
        {
            if (_numberToIndicesMap.TryGetValue(number, out var indices))
            {
                return indices.Min;
            }

            const int noIndex = -1;
            return noIndex;
        }
    }
}
