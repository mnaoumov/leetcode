using JetBrains.Annotations;

namespace LeetCode._0170_Two_Sum_III___Data_structure_design;

/// <summary>
/// https://leetcode.com/submissions/detail/882066597/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ITwoSum Create() => new TwoSum();

    private class TwoSum : ITwoSum
    {
        private readonly HashSet<int> _numbers = new();
        private readonly HashSet<int> _twoSums = new();

        public void Add(int number)
        {
            if (_numbers.Contains(number))
            {
                _twoSums.Add(number + number);
            }
            else
            {
                foreach (var otherNumber in _numbers)
                {
                    _twoSums.Add(number + otherNumber);
                }

                _numbers.Add(number);
            }
        }

        public bool Find(int value) => _twoSums.Contains(value);
    }
}
