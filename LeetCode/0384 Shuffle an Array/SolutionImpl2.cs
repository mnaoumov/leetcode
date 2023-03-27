namespace LeetCode._0384_Shuffle_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/923232252/
/// </summary>
public class SolutionImpl2 : ISolutionImpl
{
    private readonly int[] _nums;
    private readonly Random _random = new();

    public SolutionImpl2(IEnumerable<int> nums) => _nums = nums.ToArray();

    public int[] Reset() => _nums;
    public int[] Shuffle() => _nums.OrderBy(_ => _random.Next()).ToArray();
}
