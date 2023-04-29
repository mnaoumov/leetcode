namespace LeetCode._1538_Guess_the_Majority_in_a_Hidden_Array;

public class ArrayReader
{
    private readonly int[] _nums;
    public ArrayReader(int[] nums) => _nums = nums;

    public int Query(int a, int b, int c, int d) =>
        new[] { a, b, c, d }.Count(i => _nums[i] == 0) switch
        {
            0 => 4,
            4 => 4,
            1 => 2,
            3 => 2,
            2 => 0,
            _ => throw new InvalidOperationException()
        };

    public int Length() => _nums.Length;
};