namespace LeetCode.Problems._2522_Partition_String_Into_Substrings_With_Values_at_Most_K;

/// <summary>
/// https://leetcode.com/submissions/detail/869885884/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumPartition(string s, int k)
    {
        var result = 1;
        var lastValue = 0;

        foreach (var digit in s.Select(symbol => symbol - '0'))
        {
            if (digit > k)
            {
                return -1;
            }

            var value = lastValue * 10 + digit;

            if (value <= k)
            {
                lastValue = value;
            }
            else
            {
                lastValue = digit;
                result++;
            }
        }

        return result;
    }
}
