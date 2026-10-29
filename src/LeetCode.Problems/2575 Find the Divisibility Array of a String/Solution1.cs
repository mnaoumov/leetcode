namespace LeetCode.Problems._2575_Find_the_Divisibility_Array_of_a_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-334/submissions/detail/905008143/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DivisibilityArray(string word, int m)
    {
        var remainder = 0L;
        return word.Select(symbol =>
        {
            var digit = symbol - '0';
            remainder = (10 * remainder + digit) % m;
            return remainder == 0 ? 1 : 0;
        }).ToArray();
    }
}
