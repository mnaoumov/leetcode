namespace LeetCode.Problems._2083_Substrings_That_Begin_and_End_With_the_Same_Letter;

/// <seealso href="TODO url">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long NumberOfSubstrings(string s) =>
        s
            .GroupBy(letter => letter)
            .Select(g => g.Count())
            .Select(count => 1L * count * (count + 1) / 2)
            .Sum();
}
