namespace LeetCode.Problems._0170_Two_Sum_III___Data_structure_design;

/// <summary>
/// https://leetcode.com/problems/two-sum-iii-data-structure-design/submissions/1823682933/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ITwoSum Create() => new TwoSum();

    private class TwoSum : ITwoSum
    {
        private readonly HashSet<int> _numbers = new();
        private readonly HashSet<int> _numbersAppearedTwice = new();

        public void Add(int number)
        {
            if (!_numbers.Add(number))
            {
                _numbersAppearedTwice.Add(number);
            }
        }

        public bool Find(int value)
        {
            if (value % 2 == 0)
            {
                var half = value / 2;

                if (_numbersAppearedTwice.Contains(half))
                {
                    return true;
                }
            }

            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var num1 in _numbers)
            {
                var num2 = value - num1;

                if (num1 == num2)
                {
                    continue;
                }

                if (_numbers.Contains(num2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
