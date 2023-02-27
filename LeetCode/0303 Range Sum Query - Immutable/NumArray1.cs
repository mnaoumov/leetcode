namespace LeetCode._0303_Range_Sum_Query___Immutable;

/// <summary>
/// https://leetcode.com/submissions/detail/898931924/
/// </summary>
public class NumArray1 : INumArray
{
    private readonly int[] _prefixes;

    public NumArray1(IReadOnlyList<int> nums)
    {
        _prefixes = new int[nums.Count + 1];

        for (var i = 0; i < nums.Count; i++)
        {
            _prefixes[i + 1] = _prefixes[i] + nums[i];
        }
    }

    public int SumRange(int left, int right) => _prefixes[right + 1] - _prefixes[left];
}